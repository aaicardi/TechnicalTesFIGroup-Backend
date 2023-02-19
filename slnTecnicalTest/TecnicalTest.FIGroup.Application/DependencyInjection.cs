using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using TecnicalTest.FIGroup.Application.Services.Behaviors;

namespace TecnicalTest.FIGroup.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(DependencyInjection).Assembly);

        serviceCollection.AddScoped(
           typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        serviceCollection.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return serviceCollection;
    }
}

