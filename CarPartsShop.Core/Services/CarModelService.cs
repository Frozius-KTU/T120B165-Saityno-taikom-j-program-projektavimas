using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Core.Aggregates.CarModel.Specs;
using CarPartsShop.Core.Interfaces;
using CarPartsShop.Shared.Interfaces;
using CarPartsShop.Shared.Models;

namespace CarPartsShop.Core.Services;
internal class CarModelService : ICarModelService
{
    public CarModelService(IRepository<CarModelEntity> carModelRepo, IOptions<AppSettings> appSettings)
    {
        CarModelRepo = carModelRepo ?? throw new ArgumentNullException(nameof(carModelRepo));
        AppSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }
    private IRepository<CarModelEntity> CarModelRepo { get; }
    private AppSettings AppSettings { get; }
    public async Task<ICollection<CarModelEntity>> GetCarModelList(CancellationToken cancellationToken = default)
    {
        var spec = new CarModelListSpec();
        return await CarModelRepo.ListAsync(spec, cancellationToken);
    }
    public async Task<CarModelEntity?> GetCarModelById(Guid carModelId, CancellationToken cancellationToken = default)
    {
        var spec = new CarModelByIdSpec(carModelId);
        return await CarModelRepo.GetBySpecAsync(spec, cancellationToken);
    }
    public async Task<ICollection<CarModelEntity>> GetCarModelByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default)
    {
        var spec = new CarModelByBrandList(carBrandId);
        return await CarModelRepo.ListAsync(spec, cancellationToken);
    }

    public async Task<ActionResult<CarModelEntity>> CreateCarModel(CarModelEntity carModelEntity, CancellationToken cancellationToken)
    {
        return await CarModelRepo.AddAsync(carModelEntity, cancellationToken);
    }
    public async Task DeleteCarModel(Guid carModelId, CancellationToken cancellationToken = default)
    {
        var carModel = await GetCarModelById(carModelId);
        if (carModel is null) throw new ArgumentNullException(nameof(carModel));
        await CarModelRepo.DeleteAsync(carModel, cancellationToken);
    }
    public async Task<CarModelEntity> UpdateCarModel(Guid carModelId, CarModelEntity request, CancellationToken cancellationToken = default)
    {
        var carModel = await GetCarModelById(carModelId);
        if (carModel is null) throw new ArgumentNullException(nameof(carModel));
        //await CarModelRepo.UpdateAsync()*/
        carModel.Update(request);
        await CarModelRepo.SaveChangesAsync();
        return carModel;
    }
}
