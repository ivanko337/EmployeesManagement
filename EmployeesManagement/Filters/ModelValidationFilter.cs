using EmployeesManagement.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace EmployeesManagement.Filters
{
    public class ModelValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<ModelValidationFilter> _logger;

        public ModelValidationFilter(IServiceProvider provider, ILogger<ModelValidationFilter> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpMethod = context.HttpContext.Request.Method;

            if (httpMethod != "POST" && httpMethod != "PUT")
            {
                await next();
                return;
            }

            var dto = context.ActionArguments
                .FirstOrDefault(a => a.Value?.GetType().IsSubclassOf(typeof(BaseDto)) ?? false).Value as BaseDto;

            if (dto == null)
            {
                _logger.LogWarning("Cannot get dto instance for {0}", context.HttpContext.Request.Path);
                await next();
                return;
            }

            var dtoType = dto.GetType();

            using var scope = _provider.CreateScope();
            var validator = scope.ServiceProvider
                .GetRequiredService(typeof(IValidator<>).MakeGenericType(dtoType));

            if (validator == null)
            {
                _logger.LogWarning("Cannot get validator for {0}", dtoType.Name);
                await next();
                return;
            }

            var validatorType = validator.GetType();
            var method = validatorType.GetMethod(
                "ValidateAsync",
                BindingFlags.Public | BindingFlags.Instance,
                new Type[] { dtoType, typeof(CancellationToken) });

            var task = method!.Invoke(validator, new object[] { dto, CancellationToken.None }) as Task<ValidationResult>;

            var validationResult = await task;
            if (!validationResult.IsValid)
            {
                var controller = context.Controller as ControllerBase;

                validationResult.AddToModelState(controller.ModelState);
                context.Result = new BadRequestObjectResult(controller.ModelState);
            }
        }
    }
}
