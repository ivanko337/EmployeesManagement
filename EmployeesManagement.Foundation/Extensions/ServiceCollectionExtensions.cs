using EmployeesManagement.Foundation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManagement.Foundation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPositionService, PositionService>();

            return services;
        }
    }
}
