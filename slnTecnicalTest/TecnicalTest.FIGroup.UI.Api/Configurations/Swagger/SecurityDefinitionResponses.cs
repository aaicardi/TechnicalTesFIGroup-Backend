using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TecnicalTest.FIGroup.UI.Api.Configurations.Swagger;

public class SecurityDefinitionResponses : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var isAuthorized = context.MethodInfo.DeclaringType != null &&
                           (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>()
                                .Any()
                            || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>()
                                .Any()); // this excludes methods with AllowAnonymous attribute
        if (!isAuthorized) return;

        operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
        operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

        var jwtBearerScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        };

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new() {[jwtBearerScheme] = new string[] { }}
        };
    }
}

