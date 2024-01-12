using Microsoft.AspNetCore.Mvc;

namespace Versioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add API versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Add Swagger document for API version 1
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Version 1",
                    Version = "v1",
                });

                // Add Swagger document for API version 2
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Version 2",
                    Version = "v2",
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    // Enable Swagger UI for API version 1
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Version 1");

                    // Enable Swagger UI for API version 2
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API Version 2");
                });
            }

            app.UseApiVersioning();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}