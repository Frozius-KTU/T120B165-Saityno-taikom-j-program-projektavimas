using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Core.Interfaces;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Services;
internal class AuthService : IAuthService
{
    public AuthService(IRepository<ShopRestUser> repository)
    {
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public IRepository<ShopRestUser> Repository { get; }

    public async Task<ShopRestUser?> GetUserByUserId(string userId, CancellationToken cancellationToken = default)
    {
        return await Repository.GetByIdAsync(userId, cancellationToken);
    }
}
