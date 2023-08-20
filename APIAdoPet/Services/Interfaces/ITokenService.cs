using APIAdoPet.Domains;

namespace APIAdoPet.Services.Interfaces;

public interface ITokenService
{
    Task<string> GerarTokenJWT(Usuario usuario);
}

