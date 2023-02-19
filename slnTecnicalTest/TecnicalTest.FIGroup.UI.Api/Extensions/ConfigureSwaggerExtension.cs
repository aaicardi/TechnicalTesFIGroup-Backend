using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using TecnicalTest.FIGroup.UI.Api.Configurations.Swagger;

namespace TecnicalTest.FIGroup.UI.Api.Extensions;

public static class ConfigureSwaggerExtension
{
    private static string GetBasePath => AppContext.BaseDirectory;

    private static void IncludeXmlComments(SwaggerGenOptions swagger)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var xmlDocs = currentAssembly.GetReferencedAssemblies()
            .Union(new List<AssemblyName> { currentAssembly.GetName() })
            .Select(a => Path.Combine(GetBasePath, $"{a.Name}.xml"))
            .Where(File.Exists).ToList();
        xmlDocs.ForEach(d => swagger.IncludeXmlComments(d));
    }


    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Put **_ONLY_** your JWT Bearer token on text box below!"
            });

            swagger.OperationFilter<SwaggerDefaultValues>();
            swagger.OperationFilter<SecurityDefinitionResponses>();
            IncludeXmlComments(swagger);

            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TecnicalTest FIGroup",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Email = "alexaycardi@gmail.com",
                    Name = "Jhoel Aicardi",
                    Url = new Uri("https://www.linkedin.com/in/alex-jhoel-aicardi-avila-2b4069152/")
                },
                Description = "General considerations: <br /><br />" +
                              "- To avoid time zone errors, convert the dates in the responses to the local time of the device.<br />" +
                              "- All dates to be sent must have this format: <b>yyyy-MM-ddTHH:mm:ss.fffffffzzz</b><br />" +
                              "<b>e.g. 2015-01-01T06:00:00.000-05:00</b> (to handle all different time zones).<br /><br />" +
                              "For more information, please view<br /><br />" +
                              "https://docs.automationanywhere.com/bundle/enterprise-v2019/page/enterprise-cloud/topics/aae-client/bot-creator/commands/cloud-date-time-formats.html" +
                              "<br />" +
                              "https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-round-trip-o-o-format-specifier"
            });
        });
        return services;
    }
}


