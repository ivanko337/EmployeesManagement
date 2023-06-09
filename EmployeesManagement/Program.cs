using EmployeesManagement.Data.Extensions;
using EmployeesManagement.Extensions;
using EmployeesManagement.Filters;
using FluentValidation;
using System.Globalization;

namespace EmployeesManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-us");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRequiredServices(builder.Configuration);

            builder.Services.AddControllers(options =>
            {
                options.Filters.AddService(typeof(ExceptionsHandlerFilter));
                options.Filters.AddService(typeof(ModelValidationFilter));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.Services.MigrateAndSeedDatabase();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}