using BMS.Infrastructure.Persistence.Contexts;
using BMS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BMS.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MsSqlDbContext>();

        services.AddScoped<DbContext>(p => p.GetService<MsSqlDbContext>());

        services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

        return services;
    }
}