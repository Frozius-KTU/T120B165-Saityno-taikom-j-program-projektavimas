using Microsoft.AspNetCore.Mvc;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Interfaces;

namespace CarPartsShop.API.Controllers;

[ApiController]
[Route("api/carPart")]
public class CarPartController : BaseController
{
    public CarPartController(ICarPartService carPartService)
    {
        CarPartService = carPartService ?? throw new ArgumentNullException(nameof(carPartService));
    }
    private ICarPartService CarPartService { get; }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarPartModel))]
    public async Task<ICollection<CarPartModel>> GetCarPartList(CancellationToken cancellationToken = default)
    {
        try
        {
            var list = await CarPartService.GetCarPartList(cancellationToken);
            return Mapper.Map<ICollection<CarPartModel>>(list);
        }
        catch(Exception ex)
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
            //return Mapper.Map<CarPartModel>(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarPartModel>> CreateCarPart([FromBody] CarPartModel carPartModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carPartModel is null) return BadRequest();

            var createdCarPart = await CarPartService.CreateCarPart(carPartModel.ToEntity(), cancellationToken);

            return Created(nameof(CarBrandModel), Mapper.Map<CarPartModel>(carPartModel));
            //return Ok(Mapper.Map<CarPartModel>(carPartModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpDelete("{carPartId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarPartModel>> DeleteCarPart(Guid carPartId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carPartId == Guid.Empty) return NotFound();
            await CarPartService.DeleteCarPart(carPartId, cancellationToken);
            return NoContent();
            //return Mapper.Map<CarPartModel>(deletedcarPart);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPut("{carPartId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarPartModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarPartModel>> UpdateCarPart(Guid carPartId, CarPartModel carPart, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carPartId != carPart.Id) return BadRequest("Nesutampa ID");
            if (carPartId == Guid.Empty) return NotFound();
            await CarPartService.UpdateCarPart(carPartId, carPart.ToEntity(), cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
