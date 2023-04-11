using EmployeesManagement.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManagement.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmployeesDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeesDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("Default")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();

            return services;
        }
    }
}
