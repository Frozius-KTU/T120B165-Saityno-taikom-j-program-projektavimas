﻿namespace CarPartsShop.Core.Interfaces;

public interface IJwtTokenService
{
    string CreateAccessToken(string userName, string userId, IEnumerable<string> userRoles);
}