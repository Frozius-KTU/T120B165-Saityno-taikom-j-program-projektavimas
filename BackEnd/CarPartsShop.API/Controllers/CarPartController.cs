using Microsoft.AspNetCore.Mvc;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Interfaces;
using CarPartsShop.Core.Aggregates.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace CarPartsShop.API.Controllers;

[ApiController]
[Route("api/carPart")]
public class CarPartController : BaseController
{
    public CarPartController(ICarPartService carPartService, IAuthorizationService authorizationService)
    {
        CarPartService = carPartService ?? throw new ArgumentNullException(nameof(carPartService));
        _authorizationService = authorizationService;
    }
    private ICarPartService CarPartService { get; }
    private readonly IAuthorizationService _authorizationService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarPartModel))]
    public async Task<ICollection<CarPartModel>> GetCarPartList(CancellationToken cancellationToken = default)
    {
        try
        {
            var list = await CarPartService.GetCarPartList(cancellationToken);
            return Mapper.Map<ICollection<CarPartModel>>(list);
        }
        catch (Exception ex)
        {
            return (ICollection<CarPartModel>)StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpGet("{carPartId:Guid}")]
    public async Task<ActionResult<CarPartModel>> GetCarPartById([FromRoute] Guid carPartId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarPartService.GetCarPartById(carPartId);
            if (result is null) return NotFound();
            if (carPartId == Guid.Empty) return NotFound();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [Authorize(Roles = ShopRoles.ShopUser)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarPartModel>> CreateCarPart([FromBody] CarPartModel carPartModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carPartModel is null) return BadRequest();
            var carPartEntity = carPartModel.ToEntity();
            carPartEntity.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            carPartEntity.Id = Guid.NewGuid();
            var createdCarPart = await CarPartService.CreateCarPart(carPartEntity, cancellationToken);

            return Created(nameof(CarBrandModel), Mapper.Map<CarPartModel>(carPartModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{carPartId:Guid}")]
    [Authorize(Roles = ShopRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarPartModel>> DeleteCarPart(Guid carPartId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carPartId == Guid.Empty) return NotFound();
            await CarPartService.DeleteCarPart(carPartId, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPut("{carPartId:Guid}")]
    [Authorize(Roles = ShopRoles.ShopUser)]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarPartModel>> UpdateCarPart(Guid carPartId, CarPartModel carPart, CancellationToken cancellationToken = default)
    {
        var part = CarPartService.GetCarPartById(carPartId, cancellationToken);

        if (part == null)
            return NotFound();

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, part.Result, PolicyNames.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        await CarPartService.UpdateCarPart(carPartId, carPart.ToEntity(), cancellationToken);
        return NoContent();

    }
}
