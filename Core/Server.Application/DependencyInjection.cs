using Microsoft.Extensions.DependencyInjection;

namespace Server.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration =>
            {
                configuration
                    .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

        return services;
    }
}
