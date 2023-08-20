using APIAdoPet.Domains.DTO.LoginDTO;
using Microsoft.AspNetCore.Identity;

namespace APIAdoPet.Services.Interfaces;

public interface ILoginService
{
    Task<string> Login(LoginUsuarioDTO loginUsuarioDTO);
}
