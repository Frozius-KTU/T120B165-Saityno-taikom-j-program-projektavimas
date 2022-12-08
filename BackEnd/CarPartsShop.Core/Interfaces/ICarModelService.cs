using Microsoft.AspNetCore.Mvc;
using CarPartsShop.Core.Aggregates.CarModel;

namespace CarPartsShop.Core.Interfaces;
public interface ICarModelService
{
    Task<ICollection<CarModelEntity>> GetCarModelList(CancellationToken cancellationToken = default);
    Task<CarModelEntity?> GetCarModelById(Guid carModelId, CancellationToken cancellationToken = default);
    Task<ActionResult<CarModelEntity>> CreateCarModel(CarModelEntity carModelModel, CancellationToken cancellationToken = default);
    Task DeleteCarModel(Guid carModelId, CancellationToken cancellationToken = default);
    Task<CarModelEntity> UpdateCarModel(Guid carModelId, CarModelEntity carModel, CancellationToken cancellationToken = default);
    Task<ICollection<CarModelEntity>> GetCarModelByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default);
}
