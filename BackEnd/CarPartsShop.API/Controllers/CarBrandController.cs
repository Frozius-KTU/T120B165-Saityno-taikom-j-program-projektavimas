using Microsoft.AspNetCore.Mvc;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.AspNetCore.Authorization;
using CarPartsShop.Core.Aggregates.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CarPartsShop.API.Controllers;

[ApiController]
[Route("api/carBrand")]
public class CarBrandController : BaseController
{
    public CarBrandController(ICarBrandService carBrandService, ICarModelService carModelService,
        ICarPartService carPartService, IAuthorizationService authorizationService)
    {
        CarBrandService = carBrandService ?? throw new ArgumentNullException(nameof(carBrandService));
        CarModelService = carModelService ?? throw new ArgumentNullException(nameof(carModelService));
        CarPartService = carPartService ?? throw new ArgumentNullException(nameof(carPartService));
        _authorizationService = authorizationService;

    }

    private readonly IAuthorizationService _authorizationService;
    private ICarBrandService CarBrandService { get; }
    public ICarModelService CarModelService { get; }
    public ICarPartService CarPartService { get; }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    public async Task<ICollection<CarBrandModel>> GetCarBrandList(CancellationToken cancellationToken = default)
    {
        try
        {
            var list = await CarBrandService.GetCarBrandList(cancellationToken);
            //return Ok(Mapper.Map<ICollection<CarBrandModel>>(list));
            return Mapper.Map<ICollection<CarBrandModel>>(list);
        }
        catch (Exception ex)
        {
            return (ICollection<CarBrandModel>)StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("{carBrandId:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CarBrandModel>> GetCarBrandById([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarBrandService.GetCarBrandById(carBrandId);
            if (result is null) return NotFound();
            if (carBrandId == Guid.Empty) return NotFound();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("{carBrandId:Guid}/carModel")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ICollection<CarBrandModel>>> GetCarModelByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarModelService.GetCarModelByBrandList(carBrandId);
            if (carBrandId == Guid.Empty) return NotFound();
            if (result is null) return NotFound();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("{carBrandId:Guid}/carModel/{carModelId:Guid}/carPart")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ICollection<CarPartModel>>> GetCarPartByBrandList([FromRoute] Guid carBrandId, [FromRoute] Guid carModelId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarPartService.GetCarPartByBrandList(carBrandId, carModelId, cancellationToken);
            if (carBrandId == Guid.Empty) return NotFound();
            //return Mapper.Map<CarModelModel>(result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("{carBrandId:Guid}/carPart")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ICollection<CarPartModel>>> GetCarPartsByBrandList([FromRoute] Guid carBrandId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarPartService.GetCarPartsByBrandList(carBrandId, cancellationToken);
            if (carBrandId == Guid.Empty) return NotFound();
            //return Mapper.Map<CarModelModel>(result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [Authorize(Roles = ShopRoles.ShopUser)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarBrandModel>> CreateCarBrand([FromBody] CarBrandModel carBrandModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carBrandModel is null) return BadRequest();
            var carBrandEntity = carBrandModel.ToEntity();

            carBrandEntity.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            carBrandEntity.Id = Guid.NewGuid();
            var createdCarBrand = await CarBrandService.CreateCarBrand(carBrandEntity, cancellationToken);

            return Created(nameof(CarBrandModel), Mapper.Map<CarBrandModel>(carBrandModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpDelete("{carBrandId:Guid}")]
    [Authorize(Roles = ShopRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarBrandModel>> DeleteCarBrand(Guid carBrandId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carBrandId == Guid.Empty) 
                return NotFound();

            var itemToDelete = await GetCarBrandById(carBrandId, cancellationToken);

            if (itemToDelete.Result is null) 
                return NotFound();

            await CarBrandService.DeleteCarBrand(carBrandId, cancellationToken);
            return NoContent();
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.GetBaseException() as SqlException;
            if (sqlException != null)
            {
                if (sqlException.Number == 547)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
                else throw ex;
            }
            else throw ex;
        }
    }
    [HttpPut("{carBrandId:Guid}")]
    [Authorize(Roles = ShopRoles.ShopUser)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarBrandModel>> UpdateCarBrand(Guid carBrandId, CarBrandModel carBrand, CancellationToken cancellationToken = default)
    {
        var brand = CarBrandService.GetCarBrandById(carBrandId, cancellationToken);

        // 404
        if (brand == null) 
            return NotFound();

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, brand.Result, PolicyNames.ResourceOwner);
        if (!authorizationResult.Succeeded)
        {
            // 403
            return Forbid();
        }
        await CarBrandService.UpdateCarBrand(carBrandId, carBrand.ToEntity(), cancellationToken);
        return Ok(carBrand);
    }
}


