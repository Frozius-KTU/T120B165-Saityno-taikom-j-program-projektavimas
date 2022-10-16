using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Aggregates.CarModel;
public class CarModelEntity : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public CarBrandEntity? CarBrand { get; set; }
    public Guid CarBrandId { get; set; }
    public void Update(CarModelEntity request)
    {
        Name = request.Name ?? Name;
        CarBrand = request.CarBrand ?? CarBrand;
        CarBrandId = request.CarBrandId;
    }
}
