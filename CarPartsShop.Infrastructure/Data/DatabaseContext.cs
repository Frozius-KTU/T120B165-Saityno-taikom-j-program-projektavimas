
using CarPartsShop.Core.Aggregates.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarPartsShop.Infrastructure.Data;

public class DatabaseContext : IdentityDbContext<ShopRestUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> configuration) : base(configuration)
    {

    }
   // public DbSet<CarBrandEntity>? CarBrands{ get; set; }
   // public DbSet<CarModelEntity>? CarModels { get; set; }
   // public DbSet<CarPartEntity>? CarParts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}

