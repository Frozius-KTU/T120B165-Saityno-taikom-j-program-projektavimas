using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Aggregates.CarPart;
public class CarPartEntity : BaseEntity, IAggregateRoot, IUserOwnedResource
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CarModelEntity CarModel { get; set; } 
    public Guid CarModelId { get; set; }
    public int Qty { get; set; }
    public string UserId { get; set; }
    public ShopRestUser User { get; set; }
    public void Update(CarPartEntity request)
    {
        Name = request.Name ?? Name;
        Description = request.Description ?? Description;
        CarModel = request.CarModel ?? CarModel;
        CarModelId = request.CarModelId;
        Qty = request.Qty;
    }
}
