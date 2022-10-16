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
}
