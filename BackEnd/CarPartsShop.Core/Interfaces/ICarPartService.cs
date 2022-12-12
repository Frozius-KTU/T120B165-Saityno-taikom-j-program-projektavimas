using Microsoft.AspNetCore.Mvc;
using CarPartsShop.Core.Aggregates.CarPart;

namespace CarPartsShop.Core.Interfaces;
public interface ICarPartService
{
    Task<ICollection<CarPartEntity>> GetCarPartList(CancellationToken cancellationToken = default);
    Task<CarPartEntity?> GetCarPartById(Guid carPartId, CancellationToken cancellationToken = default);
    Task<ActionResult<CarPartEntity>> CreateCarPart(CarPartEntity carPartModel, CancellationToken cancellationToken = default);
    Task DeleteCarPart(Guid carPartId, CancellationToken cancellationToken = default);
    Task<CarPartEntity> UpdateCarPart(Guid carPartId, CarPartEntity carPart, CancellationToken cancellationToken = default);
    Task<ICollection<CarPartEntity>> GetCarPartByBrandList([FromRoute] Guid carBrandId, [FromRoute] Guid carModelId, CancellationToken cancellationToken = default);
    Task<ICollection<CarPartEntity>> GetCarPartsByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default);
    Task<ICollection<CarPartEntity>> GetCarPartsByUserId([FromRoute] Guid userId, CancellationToken cancellationToken = default);
    Task<ICollection<CarPartEntity>> GetCarPartsByModelId([FromRoute] Guid carModelId, CancellationToken cancellationToken = default);

}
