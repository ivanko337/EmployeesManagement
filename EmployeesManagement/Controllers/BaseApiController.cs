using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ValidationResult> ValidateAsync<T>(T obj)
        {
            using var scope = HttpContext.RequestServices.CreateScope();
            var validator = scope.ServiceProvider.GetRequiredService<IValidator<T>>();
            return await validator.ValidateAsync(obj);
        }

        protected BadRequestObjectResult BadRequestOnFailedValidation(ValidationResult result)
        {
            result.AddToModelState(ModelState);
            return BadRequest(ModelState);
        }
    }
}
