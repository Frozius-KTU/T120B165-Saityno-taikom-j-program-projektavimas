using CarPartsShop.Core.Aggregates.CarPart;

namespace CarPartsShop.Infrastructure.Data.Config;

public abstract class CarPartEntityConfiguration : BaseEntityConfiguration<CarPartEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CarPartEntity> builder)
    {
        builder.ToTable("CarParts");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32)
            .HasColumnType("nvarchar(32)");
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("nvarchar(1000)");
        builder.HasOne(x => x.CarModel)
           .WithMany()
           .HasForeignKey(x => x.CarModelId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Qty)
            .IsRequired();
    }
}
