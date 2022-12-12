using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Interfaces;
using System.Net;
using CarPartsShop.Core.Aggregates.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using CarPartsShop.Core.Aggregates.CarBrand;

namespace CarPartsShop.API.Controllers;

[ApiController]
[Route("api/carModel")]
public class CarModelController : BaseController
{
    public CarModelController(ICarModelService carModelService, ICarPartService carPartService, IAuthorizationService authorizationService)
    {
        CarModelService = carModelService ?? throw new ArgumentNullException(nameof(carModelService));
        CarPartService = carPartService ?? throw new ArgumentNullException(nameof(carPartService));
        _authorizationService = authorizationService;
    }

    private ICarModelService CarModelService { get; }
    public ICarPartService CarPartService { get; }

    private readonly IAuthorizationService _authorizationService;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarModelModel))]
    public async Task<ICollection<CarModelModel>> GetCarModelList(CancellationToken cancellationToken = default)
    {
        try
        {
            var list = await CarModelService.GetCarModelList(cancellationToken);
            return Mapper.Map<ICollection<CarModelModel>>(list);
        }
        catch (Exception ex)
        {
            return (ICollection<CarModelModel>)StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("{carModelId:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarModelModel>> GetCarModelById([FromRoute] Guid carModelId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarModelService.GetCarModelById(carModelId);
            if (result is null) return NotFound();
            if (carModelId == Guid.Empty) return NotFound();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("{carModelId:Guid}/carPart")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarBrandModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ICollection<CarPartModel>>> GetCarPartsByModelId([FromRoute] Guid carModelId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarPartService.GetCarPartsByModelId(carModelId, cancellationToken);
            if (carModelId == Guid.Empty) return NotFound();
            //return Mapper.Map<CarModelModel>(result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [Authorize(Roles = ShopRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarModelModel>> CreateCarModel([FromBody] CarModelModel carModelModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carModelModel is null) return BadRequest();
            var carModelEntity = carModelModel.ToEntity();

            carModelEntity.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            carModelEntity.Id = Guid.NewGuid();
            var createdCarModel = await CarModelService.CreateCarModel(carModelEntity, cancellationToken);

            return Created(nameof(CarBrandModel), Mapper.Map<CarModelModel>(carModelModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpDelete("{carModelId:Guid}")]
    [Authorize(Roles = ShopRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarModelModel>> DeleteCarModel(Guid carModelId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carModelId == Guid.Empty) return NotFound();
            await CarModelService.DeleteCarModel(carModelId, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPut("{carModelId:Guid}")]
    [Authorize(Roles = ShopRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarModelModel>> UpdateCarModel(Guid carModelId, CarModelModel carModel, CancellationToken cancellationToken = default)
    {
        var model = CarModelService.GetCarModelById(carModelId, cancellationToken);

        // 404
        if (model == null)
            return NotFound();

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, model.Result, PolicyNames.ResourceOwner);
        if (!authorizationResult.Succeeded)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, authorizationResult.Failure);
            //return Forbid();
        }
        await CarModelService.UpdateCarModel(carModelId, carModel.ToEntity(), cancellationToken);
        return Ok(carModel);


    }
}
