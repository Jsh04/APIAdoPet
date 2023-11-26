using APIAdoPet.Domains.DTO.UsuarioDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class UsuarioController
{

    [HttpGet("{id}")]
    public IActionResult RetornarUsuarioPeloId(UsuarioRetornarDTO usuarioRetornarDTO)
    {
        throw new NotImplementedException();
    }

}
