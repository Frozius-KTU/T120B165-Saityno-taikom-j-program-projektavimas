using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CarPartsShop.Shared.Models;

namespace CarPartsShop.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IMapper Mapper =>
        HttpContext.RequestServices.GetRequiredService<IMapper>();

    protected IConfiguration Configuration =>
        HttpContext.RequestServices.GetRequiredService<IConfiguration>();
}
