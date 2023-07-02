using APIAdoPet.Data;
using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;


[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{
	private readonly APIAdopetContext _context;

	private readonly IMapper _mapper;

	public TutorController(APIAdopetContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpPost]
	public IActionResult cadastrarTutor([FromBody] CadastrarTutorDTO tutorDto)
	{
		var tutor = _mapper.Map<Tutor>(tutorDto);
		_context.Tutores.Add(tutor);
		_context.SaveChanges();
		return CreatedAtAction(nameof(PegarTutorPorId), new { id = tutor.Id }, tutor);
	}

	[HttpGet]
	public IEnumerable<ListarTutorDTO> ListarTutores([FromQuery] int skip = 0, [FromQuery] int take = 10)
	{
		IQueryable<Tutor> tutors = _context.Tutores.Skip(skip).Take(take);	
		return _mapper.Map<List<ListarTutorDTO>>(tutors.ToList());
	}

	[HttpGet("{id}")]
	public IActionResult PegarTutorPorId(int id)
	{
		var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
		if (tutor == null) return NotFound();
		var tutorDTO = _mapper.Map<ListarTutorDTO>(tutor);
		return Ok(tutorDTO);
	}

	[HttpPut("{id}")]
	public IActionResult AtualizarFilme(int id, [FromBody] AtualizaTutorDTO tutorDTO)
	{
		var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
		if(tutor == null) return NotFound();
		_mapper.Map(tutorDTO, tutor);
		_context.SaveChanges();
		return NoContent();
	}
	[HttpDelete("{id}")]
	public IActionResult DeletarTutor(int id)
	{
		var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
		if(tutor != null)
		{
        _context.Tutores.Remove(tutor);
		_context.SaveChanges();
		return NoContent();
		}
		return BadRequest();
	}
}
