using APIAdoPet.Domains;
using APIAdoPet.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAdoPet.Services;

public class TokenService : ITokenService
{

    private readonly UserManager<Usuario> _userManager;

    public TokenService(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }


    public async Task<string> GerarTokenJWT(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var roleUser =  await RetornarRole(usuario);
        
        var claims = new ClaimsIdentity(new[]
        {
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.Name, usuario.UserName),
            new Claim(ClaimTypes.Role, roleUser.Name)
        });

        var chave = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes("vmçOJDhvPOSEIhvPSOIjkhfnP"));

        SigningCredentials signingCredentials = new(chave, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = claims,
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }

    private async Task<IdentityRole> RetornarRole(Usuario usuario)
    {
        var roles = await _userManager.GetRolesAsync(usuario);
        return new IdentityRole(roles.First());
    }


}
