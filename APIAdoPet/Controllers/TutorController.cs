using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APIAdoPet.Infraestrutura.Repository;

namespace APIAdoPet.Controllers;


[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{
	private readonly TutorRepository _tutorRepository;

	private readonly IMapper _mapper;

	public TutorController(TutorRepository tutorRepository, IMapper mapper)
	{
		_tutorRepository = tutorRepository;
		_mapper = mapper;
	}

	[HttpPost]
	public IActionResult CadastrarTutor([FromBody] CadastrarTutorDTO tutorDto)
	{
		var tutor = _mapper.Map<Tutor>(tutorDto);
		_tutorRepository.CadastrarTutor(tutor);
		return CreatedAtAction(nameof(PegarTutorPorId), new { id = tutor.Id }, tutor);
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
