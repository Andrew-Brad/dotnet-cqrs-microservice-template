using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PROJECT_NAME.Api.Configurations.Extensions
{
    public static class SwaggerConfigurationExtensions
    {
        internal static void UseSwaggerDocumentation(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }

        internal static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PROJECT_NAME API",
                    Description = "API endpoints for the PROJECT_NAME API",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty,
                    }
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "PROJECT_NAME API",
                    Description = "API endpoints for the PROJECT_NAME API",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty,
                    }
                });

                c.DescribeAllEnumsAsStrings();
            });
        }
    }
}
