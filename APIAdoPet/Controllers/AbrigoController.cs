
using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains.Interfaces;
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
        _abrigoRepository = abrigoRepository;
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
        return _mapper.Map<List<DadosDetalhamentoAbrigo>>(_abrigoRepository.ListarAbrigo(skip, take));

    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAbrigo(int id, AtualizaAbrigoDTO abrigoDTO)
    {
        var abrigo = _abrigoRepository.PegarAbrigoPorId(id);
        var abrigoRequisicao = _mapper.Map(abrigoDTO, abrigo);
        var abrigoAtuzalizado = _abrigoRepository.AtualizarAbrigo(id, abrigoRequisicao);
        if (abrigoAtuzalizado == null) return NotFound();
        return Ok(abrigoAtuzalizado);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAbrigo(int id, [FromBody] AtualizarAbrigoDTO abrigoDTO)
    {
        var abrigo = _abrigoRepository.PegarAbrigoPorId(id);
        var abrigoRequisicao = _mapper.Map(abrigoDTO, abrigo);
        var abrigoAtualizado = _abrigoRepository.AtualizarAbrigo(id, abrigoRequisicao);
        if (abrigoAtualizado == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAbrigo(int id) {
        _abrigoRepository.DeletarAbrigo(id);
        return NoContent();

    }


}
