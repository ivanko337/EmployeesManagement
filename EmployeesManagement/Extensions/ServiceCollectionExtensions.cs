using EmployeesManagement.Common;
using EmployeesManagement.Data.Extensions;
using EmployeesManagement.Filters;
using EmployeesManagement.Foundation.Extensions;
using FluentValidation;

namespace EmployeesManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEmployeesDbContext(configuration);
            services.AddRepositories();
            services.AddServices();

            services.AddScoped<ExceptionsHandlerFilter>();
            services.AddScoped<ModelValidationFilter>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Scoped);

            return services;
        }
    }
}
