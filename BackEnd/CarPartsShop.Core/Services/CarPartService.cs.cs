using Microsoft.Extensions.Options;
using CarPartsShop.Core.Aggregates.CarPart.Specs;
using CarPartsShop.Core.Aggregates.CarPart;
using CarPartsShop.Shared.Interfaces;
using CarPartsShop.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using CarPartsShop.Core.Aggregates.CarModel.Specs;
using CarPartsShop.Core.Interfaces;

namespace CarPartsShop.Core.Services;
internal class CarPartService : ICarPartService
{
    public CarPartService(IRepository<CarPartEntity> carPartRepo, IOptions<AppSettings> appSettings)
    {
        CarPartRepo = carPartRepo ?? throw new ArgumentNullException(nameof(carPartRepo));
        AppSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }
    private IRepository<CarPartEntity> CarPartRepo { get; }
    private AppSettings AppSettings { get; }
    public async Task<ICollection<CarPartEntity>> GetCarPartList(CancellationToken cancellationToken = default)
    {
        var spec = new CarPartListSpec();
        return await CarPartRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<ICollection<CarPartEntity>> GetCarPartsByUserId([FromRoute] Guid userId, CancellationToken cancellationToken = default)
    {
        var spec = new CarPartsByUserIdSpec(userId);
        return await CarPartRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<CarPartEntity?> GetCarPartById(Guid carPartId, CancellationToken cancellationToken = default)
    {
        var spec = new CarPartByIdSpec(carPartId);
        return await CarPartRepo.GetBySpecAsync(spec, cancellationToken);
    }
    public async Task<ICollection<CarPartEntity>> GetCarPartByBrandList([FromRoute] Guid carBrandId, [FromRoute] Guid carModelId, CancellationToken cancellationToken = default)
    {
        var spec = new CarPartByBrandIdSpec(carBrandId, carModelId);
        return await CarPartRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<ICollection<CarPartEntity>> GetCarPartsByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default)
    {
        var spec = new CarPartsByBrandIdSpec(carBrandId);
        return await CarPartRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<ICollection<CarPartEntity>> GetCarPartsByModelId([FromRoute] Guid carModelId, CancellationToken cancellationToken = default)
    {
        var spec = new CarPartsByModelIdSpec(carModelId);
        return await CarPartRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<ActionResult<CarPartEntity>> CreateCarPart(CarPartEntity carPartEntity, CancellationToken cancellationToken)
    {
        return await CarPartRepo.AddAsync(carPartEntity, cancellationToken);
    }
    public async Task DeleteCarPart(Guid carPartId, CancellationToken cancellationToken = default)
    {
        var carPart = await GetCarPartById(carPartId);
        if (carPart is null) throw new ArgumentNullException(nameof(carPart));
        await CarPartRepo.DeleteAsync(carPart, cancellationToken);
    }
    public async Task<CarPartEntity> UpdateCarPart(Guid carPartId, CarPartEntity request, CancellationToken cancellationToken = default)
    {
        var carPart = await GetCarPartById(carPartId);
        if (carPart is null) throw new ArgumentNullException(nameof(carPart));
        //await CarPartRepo.UpdateAsync()*/
        carPart.Update(request);
        await CarPartRepo.SaveChangesAsync();
        return carPart;

    }
}
