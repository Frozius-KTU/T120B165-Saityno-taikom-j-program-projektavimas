using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Interfaces;
using System.Net;

namespace CarPartsShop.API.Controllers;

[ApiController]
[Route("api/carModel")]
public class CarModelController : BaseController
{
    public CarModelController(ICarModelService carModelService)
    {
        CarModelService = carModelService ?? throw new ArgumentNullException(nameof(carModelService));
    }

    private ICarModelService CarModelService { get; }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarModelModel))]
    public async Task<ICollection<CarModelModel>> GetCarModelList(CancellationToken cancellationToken = default)
    {
        try
        {
            var list = await CarModelService.GetCarModelList(cancellationToken);
            return Mapper.Map<ICollection<CarModelModel>>(list);
        }
        catch(Exception ex)
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
            //return Mapper.Map<CarModelModel>(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarModelModel>> CreateCarModel([FromBody] CarModelModel carModelModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carModelModel is null) return BadRequest();

            var createdCarModel = await CarModelService.CreateCarModel(carModelModel.ToEntity(), cancellationToken);

            return Created(nameof(CarBrandModel), Mapper.Map<CarModelModel>(carModelModel));
            //return Ok(Mapper.Map<CarModelModel>(carModelModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpDelete("{carModelId:Guid}")]
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
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CarModelModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarModelModel>> UpdateCarModel(Guid carModelId, CarModelModel carModel, CancellationToken cancellationToken = default)
    {
        try
        {
            if (carModelId != carModel.Id) return BadRequest("Nesutampa ID");
            if (carModelId == Guid.Empty) return NotFound();
            await CarModelService.UpdateCarModel(carModelId, carModel.ToEntity(), cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
