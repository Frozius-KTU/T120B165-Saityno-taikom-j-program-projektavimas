using CarPartsShop.API.Models;
using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarPartsShop.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api")]
public class AuthController : BaseController
{
    private readonly UserManager<ShopRestUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IAuthService authService, UserManager<ShopRestUser> userManager, ICarPartService carPartService, IJwtTokenService jwtTokenService)
    {
        CarPartService = carPartService ?? throw new ArgumentNullException(nameof(carPartService));
        AuthService = authService ?? throw new ArgumentNullException(nameof(authService));
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }
    private ICarPartService CarPartService { get; }
    private IAuthService AuthService { get; }
    [HttpGet("user/{userId:Guid}/carParts")]
    public async Task<ActionResult<CarPartModel>> GetCarPartByUserId([FromRoute] Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await CarPartService.GetCarPartsByUserId(userId);
            if (result is null) return NotFound();
            if (userId == Guid.Empty) return NotFound();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterUserModel registerUserModel)
    {
        var user = await _userManager.FindByNameAsync(registerUserModel.UserName);
        if (user != null)
            return BadRequest("Request invalid.");

        var newUser = new ShopRestUser
        {
            Email = registerUserModel.Email,
            UserName = registerUserModel.UserName
        };
        var createUserResult = await _userManager.CreateAsync(newUser, registerUserModel.Password);
        if (!createUserResult.Succeeded)
            return BadRequest(createUserResult.Errors);

        await _userManager.AddToRoleAsync(newUser, ShopRoles.ShopUser);

        return CreatedAtAction(nameof(Register), new UserModel(newUser.Id, newUser.UserName, newUser.Email));
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.UserName);
        if (user == null)
            return StatusCode(StatusCodes.Status401Unauthorized, "INCORRECT_CREDENTIALS");
            //return BadRequest("User name or password is invalid.");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);
        if (!isPasswordValid)
            return StatusCode(StatusCodes.Status401Unauthorized, "INCORRECT_CREDENTIALS");

        // valid user
        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

        return Ok(new SuccessfulLoginModel(accessToken));
    }
    [HttpGet("current")]
    public async Task<ActionResult> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (userId == null) return Ok(null);

        var result = await AuthService.GetUserByUserId(userId);
        return Ok(result);
    }
}
