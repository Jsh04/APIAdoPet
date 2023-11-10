using APIAdoPet.Domains.DTO.LoginDTO;
using APIAdoPet.Exception;
using APIAdoPet.Services;
using APIAdoPet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;


[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _service;

    public LoginController(ILoginService loginService)
    {
        _service = loginService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO usuarioDTO)
    {
            var token = await _service.Login(usuarioDTO);
            return Ok(new
            {
                    Token = token
            }); 
    }
}
