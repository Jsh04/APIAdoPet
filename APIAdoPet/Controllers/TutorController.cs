using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APIAdoPet.Domains.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace APIAdoPet.Controllers;


[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{
	private readonly ITutorRepository _tutorRepository;

	private readonly IMapper _mapper;

	private readonly UserManager<Usuario> _userManager;

	public TutorController(ITutorRepository tutorRepository, IMapper mapper, UserManager<Usuario> userManager)
	{
		_tutorRepository = tutorRepository;
		_userManager = userManager;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> CadastrarTutor([FromBody] CadastrarTutorDTO tutorDto)
	{
		Usuario usuario = new()
		{
			UserName = tutorDto.Nome.Replace(" ", ""),
			Email = tutorDto.Email
		};
		var tutor = _mapper.Map<Tutor>(tutorDto);
		tutor.Usuario = usuario;
		var resultado = await _userManager.CreateAsync(usuario, tutorDto.Senha);
		_tutorRepository.CadastrarTutor(tutor);
		if (resultado.Succeeded)
			return CreatedAtAction(nameof(PegarTutorPorId), new { id = tutor.Id }, tutor);
		else
			return BadRequest("Credencias Inválidadas");
	}

	[HttpGet]
	public IEnumerable<ListarTutorDTO> ListarTutores([FromQuery] int skip = 0, [FromQuery] int take = 10)
	{
		return _mapper.Map<List<ListarTutorDTO>>(_tutorRepository.ListarTutor(skip, take));
	}

	[HttpGet("{id}")]
	public IActionResult PegarTutorPorId(int id)
	{
		var tutor = _tutorRepository.PegarTutorPorId(id);
		if (tutor == null) return NotFound();
		var tutorDTO = _mapper.Map<ListarTutorDTO>(tutor);
		return Ok(tutorDTO);
	}

	[HttpPut("{id}")]
	public IActionResult AtualizarTutor(int id, [FromBody] AtualizaTutorDTO tutorDTO)
	{
		var tutor = _tutorRepository.PegarTutorPorId(id);
		var tutorRequisicao = _mapper.Map(tutorDTO, tutor);
		var tutorAtualizado = _tutorRepository.AtualizarTutor(id, tutorRequisicao);
		if(tutorAtualizado == null) return NotFound();
		return NoContent();
	}
	[HttpDelete("{id}")]
	public IActionResult DeletarTutor(int id)
	{
		_tutorRepository.DeletarTutor(id);
		return NoContent();
	}
}
