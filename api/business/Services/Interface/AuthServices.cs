using System.Security.Claims;
using business.Services.Implement;

namespace business.Services.Interface;

public interface IAuthServices
{
    string? GenerateJwt(List<Claim> claims,EnTokenMode tokenType);
    Claim? GetPayloadFromToken(string key, string token);
}