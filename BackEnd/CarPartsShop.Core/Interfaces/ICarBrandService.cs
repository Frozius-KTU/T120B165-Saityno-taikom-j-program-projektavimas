using Microsoft.AspNetCore.Mvc;
using CarPartsShop.Core.Aggregates.CarBrand;

namespace CarPartsShop.Core.Interfaces;
public interface ICarBrandService
{
    Task<ICollection<CarBrandEntity>> GetCarBrandList(CancellationToken cancellationToken = default);
    Task<CarBrandEntity?> GetCarBrandById(Guid carBrandId, CancellationToken cancellationToken = default);
    Task<ActionResult<CarBrandEntity>> CreateCarBrand(CarBrandEntity carBrandModel, CancellationToken cancellationToken = default);
    Task DeleteCarBrand(Guid carBrandId, CancellationToken cancellationToken = default);
    Task<CarBrandEntity> UpdateCarBrand(Guid carBrandId, CarBrandEntity carBrand, CancellationToken cancellationToken = default);
}
