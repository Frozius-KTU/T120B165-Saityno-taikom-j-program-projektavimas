using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.API.Models;

public record RegisterUserModel([Required] string UserName, [EmailAddress][Required] string Email, [Required] string Password);

public record LoginModel(string UserName, string Password);

public record UserModel(string Id, string UserName, string Email);

public record SuccessfulLoginModel(string AccessToken);