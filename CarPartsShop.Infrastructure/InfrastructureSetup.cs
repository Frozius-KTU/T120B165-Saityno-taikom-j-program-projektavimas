using CarPartsShop.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CarPartsShop.Infrastructure;

public static class InfrastructureSetup
{
    public static void AddAppDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(connectionString));
}

