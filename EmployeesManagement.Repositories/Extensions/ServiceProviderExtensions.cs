using EmployeesManagement.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeesManagement.Data.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider SeedDatabase(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EmployeesDbContext>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger(nameof(ServiceProviderExtensions));

                try
                {
                    if (!context.Positions.Any())
                    {
                        context.AddRange(new[]
                        {
                            new Position()
                            {
                                Title = "Junior .NET Developer",
                                Grade = 5
                            },
                            new Position()
                            {
                                Title = "MIddle .NET Developer",
                                Grade = 10
                            },
                            new Position()
                            {
                                Title = "Senior .NET Developer",
                                Grade = 15
                            },
                        });
                    }

                    if (!context.Employees.Any())
                    {
                        context.AddRange(new []
                        {
                            new Employee()
                            {
                                FirstName = "Мелитриса",
                                SecondName = "Шаповалова",
                                Patronymic = "Михайловна",
                                BirthDate = new DateTime(1990, 10, 23),
                            },
                            new Employee()
                            {
                                FirstName = "Остап",
                                SecondName = "Чернышов",
                                Patronymic = "Ермакович",
                                BirthDate = new DateTime(1980, 6, 14),
                            }
                        });
                    }
                    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to seed data");
                }
            }

            return provider;
        }
    }
}
