using EmployeesManagement.Common;
using EmployeesManagement.Data.Extensions;
using EmployeesManagement.Filters;
using EmployeesManagement.Foundation.Extensions;

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

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            return services;
        }
    }
}
