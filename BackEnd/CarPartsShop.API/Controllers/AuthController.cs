using CarPartsShop.API.Models;
using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsShop.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api")]
public class AuthController : BaseController
{
    private readonly UserManager<ShopRestUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(UserManager<ShopRestUser> userManager, IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
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
            return BadRequest("User name or password is invalid.");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);
        if (!isPasswordValid)
            return BadRequest("User name or password is invalid.");

        // valid user
        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);

        return Ok(new SuccessfulLoginModel(accessToken));
    }
}
