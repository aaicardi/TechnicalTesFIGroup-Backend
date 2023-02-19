using System.Text.Json.Serialization;

using TecnicalTest.FIGroup.UI.Api.Filters;
using TecnicalTest.FIGroup.Infrastructure.Common.Converters;

namespace TecnicalTest.FIGroup.UI.Api.Extensions;

public static class ConfigureControllersExtension
{
    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers(opt => opt.Filters.Add<ApiExceptionFilter>())
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                o.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                o.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
            });
        services.AddRouting(o =>
        {
            o.LowercaseUrls = true;
            o.LowercaseQueryStrings = true;
        });
        return services;
    }
}
