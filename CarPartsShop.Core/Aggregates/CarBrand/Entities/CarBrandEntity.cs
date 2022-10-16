using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Aggregates.CarBrand;
public class CarBrandEntity : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public void Update(CarBrandEntity request)
    {
        Name = request.Name ?? Name;
    }
}
