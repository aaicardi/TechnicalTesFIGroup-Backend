using Microsoft.IdentityModel.Logging;

using TecnicalTest.FIGroup.Application;
using TecnicalTest.FIGroup.Infrastructure;
using TecnicalTest.FIGroup.UI.Api.Extensions;


IdentityModelEventSource.ShowPII = true;
var MyAllowSpecificOrigins = "corsPolicy";


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.ConfigureApiVersioning();
    builder.Services.ConfigureControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(MyAllowSpecificOrigins,
            p =>
             p.WithOrigins("*")
            .AllowAnyMethod()
            // .SetIsOriginAllowed(origin => true)
            .AllowAnyHeader());
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureSwagger();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseCors(MyAllowSpecificOrigins);
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

