using APIAdoPet.Domains.DTO.LoginDTO;
using APIAdoPet.Services.Interfaces;
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

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO usuarioDTO)
    {
        var resultado = await _service.Login(usuarioDTO);
        if (resultado.Succeeded) 
        {
            return Ok("Usuario autenticado com sucesso!");
        }
        return BadRequest();
    }


}
