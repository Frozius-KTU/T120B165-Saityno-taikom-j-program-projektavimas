using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Core.Interfaces;
using CarPartsShop.Shared.Interfaces;
using CarPartsShop.Shared.Models;

namespace CarPartsShop.Core.Services;
internal class CarBrandService : ICarBrandService
{
    public CarBrandService(IRepository<CarBrandEntity> carBrandRepo, IOptions<AppSettings> appSettings)
    {
        CarBrandRepo = carBrandRepo ?? throw new ArgumentNullException(nameof(carBrandRepo));
        AppSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }
    private IRepository<CarBrandEntity> CarBrandRepo { get; }
    private AppSettings AppSettings { get; }

    public async Task<ICollection<CarBrandEntity>> GetCarBrandList(CancellationToken cancellationToken = default)
    {
        return await CarBrandRepo.ListAsync(cancellationToken);
    }
    public async Task<CarBrandEntity?> GetCarBrandById(Guid carBrandId, CancellationToken cancellationToken = default)
    {
        return await CarBrandRepo.GetByIdAsync(carBrandId, cancellationToken);
    }
    public async Task<ActionResult<CarBrandEntity>> CreateCarBrand(CarBrandEntity carBrandEntity, CancellationToken cancellationToken)
    {
        return await CarBrandRepo.AddAsync(carBrandEntity, cancellationToken);
    }
    public async Task DeleteCarBrand(Guid carBrandId, CancellationToken cancellationToken = default)
    {
        var carBrand = await GetCarBrandById(carBrandId);
        if (carBrand is null) throw new ArgumentNullException(nameof(carBrand));
        await CarBrandRepo.DeleteAsync(carBrand, cancellationToken);
    }
    public async Task<CarBrandEntity> UpdateCarBrand(Guid carBrandId, CarBrandEntity request, CancellationToken cancellationToken = default)
    {
        var carBrand = await GetCarBrandById(carBrandId);
        if (carBrand is null) throw new ArgumentNullException(nameof(carBrand));
        //await CarBrandRepo.UpdateAsync()*/
        carBrand.Update(request);
        await CarBrandRepo.SaveChangesAsync();
        return carBrand;

    }
}
