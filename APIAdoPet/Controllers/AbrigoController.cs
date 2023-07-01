using APIAdoPet.Data;
using APIAdoPet.Models;
using APIAdoPet.Models.DTO.AbrigosDTO;
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
}
