
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Core.Aggregates.CarPart;

namespace CarPartsShop.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> configuration) : base(configuration)
    {

    }
    public DbSet<CarBrandEntity>? CarBrands{ get; set; }
    public DbSet<CarModelEntity>? CarModels { get; set; }
    public DbSet<CarPartEntity>? CarParts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}

