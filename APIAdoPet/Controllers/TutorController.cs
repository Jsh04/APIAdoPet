using APIAdoPet.Domains.DTO.TutorDTO;
using Microsoft.AspNetCore.Mvc;
using APIAdoPet.Services.Interfaces;
using APIAdoPet.Exception;
using Microsoft.AspNetCore.Authorization;

namespace APIAdoPet.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Tutor", AuthenticationSchemes = "Bearer")]
public class TutorController : ControllerBase
{
	private readonly ITutorService _service;

	public TutorController(ITutorService service)
	{
		_service = service;
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> CadastrarTutor([FromBody] CadastrarTutorDTO tutorDto)
	{
		try
		{
            var tutor = await _service.CadastrarTutor(tutorDto);

            return CreatedAtAction(nameof(PegarTutorPorId), new { id = tutor.Id }, tutor);
        }
        catch(HttpResponseException ex)
		{
			return BadRequest(new HttpResponseException(ex.StatusCode, ex.Message));
		}
	}

	[HttpGet]
	public IActionResult ListarTutores([FromQuery] int skip = 0, [FromQuery] int take = 10)
	{
		return Ok(_service.ListarTutores(skip, take));
	}

	[HttpGet("{id}")]
	public IActionResult PegarTutorPorId(int id)
	{
		var tutorDTO = _service.PegarTutorPorId(id);
		return Ok(tutorDTO);
	}

	[HttpPut("{id}")]
	public IActionResult AtualizarTutor(int id, [FromBody] AtualizaTutorDTO tutorDTO)
	{
        try
        {
            _service.AtualizarTutorPorId(id, tutorDTO);
            return NoContent();
        }
        catch (HttpResponseException ex)
        {
            if(ex.StatusCode == 404)
				return NotFound(new { Error = ex.Value }); 
			return BadRequest(new { Error = ex.Message });

        }
        catch (System.Exception ex)
        {
            return BadRequest(new { Error = ex.Message});
        }

    }
	[HttpDelete("{id}")]
	public IActionResult DeletarTutor(int id)
	{
		try
		{
			_service.DeletarTutorPorId(id);
            return NoContent();
        }
        catch (HttpResponseException ex)
		{
            if (ex.StatusCode == 404)
				return NotFound(new { Error = ex.Value });
			return BadRequest(new { Error = ex.Value });
        }
		
	}
}
