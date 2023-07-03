
using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
public class AbrigoController : ControllerBase
{
    private readonly IAbrigoRepository _abrigoRepository;
    private readonly IMapper _mapper;

    public AbrigoController(IMapper mapper, IAbrigoRepository abrigoRepository)
    {
        _mapper = mapper;
        _abrigoRepository = abrigoRepository;
    }

    [HttpPost]
    public IActionResult CadastrarAbrigo([FromBody] CadastrarAbrigoDTO abrigoDTO)
    {
        var abrigo = _mapper.Map<Abrigo>(abrigoDTO);
        _abrigoRepository.CadastrarAbrigo(abrigo);
        return CreatedAtAction(nameof(PegarAbrigoPorId), new { id = abrigo.Id }, abrigo);
    }

    [HttpGet("{id}")]
    public IActionResult PegarAbrigoPorId(int id)
    {
        var abrigo = _abrigoRepository.PegarAbrigoPorId(id);
        if(abrigo != null)
        {
            return Ok(_mapper.Map<DadosDetalhamentoAbrigo>(abrigo));
        }
        return BadRequest();
    }

    

    [HttpGet]
    public IEnumerable<DadosDetalhamentoAbrigo> ListarAbrigos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var abrigos = _abrigoRepository.ListarAbrigo(skip, take);
        return _mapper.Map<List<DadosDetalhamentoAbrigo>>(abrigos.ToList());

    }
}
