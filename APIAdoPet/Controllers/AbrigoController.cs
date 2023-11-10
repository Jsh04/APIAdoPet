
using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Abrigo", AuthenticationSchemes = "Bearer")]
public class AbrigoController : ControllerBase
{
    private readonly IAbrigoRepository _abrigoRepository;
    private readonly IMapper _mapper;
    private readonly IAbrigoService _abrigoService;

    public AbrigoController(IMapper mapper, IAbrigoRepository abrigoRepository, IAbrigoService abrigoService)
    {
        _abrigoRepository = abrigoRepository;
        _mapper = mapper;
        _abrigoService = abrigoService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CadastrarAbrigo([FromBody] CadastrarAbrigoDTO abrigoDTO)
    {
        var abrigo = await _abrigoService.CadastrarAbrigo(abrigoDTO);

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
