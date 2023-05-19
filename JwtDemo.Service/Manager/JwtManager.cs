using JwtDemo.Entities.Concrete;
using JwtDemo.Service.Abstract;
using JwtDemo.Service.StringInfos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtDemo.Service.Manager;

public class JwtManager : IJwtService
{
    public string GenerateToken(AppUser appUser, List<AppRole> appRoles)
    {
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: JwtInfo.Issur,
            audience: JwtInfo.Audience,
            claims: GetClaims(appUser, appRoles),
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(JwtInfo.ExpiresTime),
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler handler = new();

        return handler.WriteToken(jwtSecurityToken);
    }

    private List<Claim> GetClaims(AppUser appUser, List<AppRole> appRoles)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, appUser.Username!),
            new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString())
        };

        if (appRoles.Count > 0)
            foreach (var item in appRoles)
                claims.Add(new Claim(ClaimTypes.Role, item.Name!));

        return claims;
    }
}
