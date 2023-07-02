
using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Infraestrutura.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class AbrigoController : ControllerBase
{
    private readonly APIAdopetContext _context;
    private readonly IMapper _mapper;

    public AbrigoController(APIAdopetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarAbrigo([FromBody] CadastrarAbrigoDTO abrigoDTO)
    {
        var abrigo = _mapper.Map<Abrigo>(abrigoDTO);
        _context.Abrigo.Add(abrigo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(PegarAbrigoPorId), new { id = abrigo.Id }, abrigo);
    }

    [HttpGet("{id}")]
    public IActionResult PegarAbrigoPorId(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);
        if(abrigo != null)
        {
            return Ok(_mapper.Map<DadosDetalhamentoAbrigo>(abrigo));
        }
        return BadRequest();
    }

    

    [HttpGet]
    public IEnumerable<DadosDetalhamentoAbrigo> ListarAbrigos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var abrigos = _context.Abrigo.Skip(skip).Take(take);
        return _mapper.Map<List<DadosDetalhamentoAbrigo>>(abrigos.ToList());

    }
}
