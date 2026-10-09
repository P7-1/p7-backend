using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HomeServices.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(config => 
        {
            config.RegisterServicesFromAssembly(assembly);
        });
        
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
