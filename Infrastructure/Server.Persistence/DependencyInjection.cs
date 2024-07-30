using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Repositories;
using Server.Persistence.Contexts;
using Server.Persistence.Repositories;

namespace Server.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services
            .AddScoped<IJwtProvider, JwtProvider>();

        string connectionString = configuration
            .GetConnectionString("MsSql") ?? string.Empty;

        services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        return services;
    }
}
