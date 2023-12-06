using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AdocaoDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize (AuthenticationSchemes = "Bearer")]
public class AdocaoController : ControllerBase
{
    private readonly IAdocaoRepository _adocaoRepository;
    private readonly IAdocaoService _adocaoService;
    private readonly IPetService _petService;

    public AdocaoController(IAdocaoRepository adocaoRepository, IMapper mapper, 
        IAdocaoService adocaoService, IPetService petService)
    {
        _adocaoService = adocaoService;
        _adocaoRepository = adocaoRepository;
        _petService = petService;
    }

    [HttpPost]
    [Authorize(Roles = "Tutor")]
    public IActionResult CadastrarAdocao(CadastrarAdocaoDTO adocaoDTO)
    {
        var dadosRetorno = _adocaoService.CadastrarAdocao(adocaoDTO);
        return CreatedAtAction(nameof(PegarAdocaoPorId), new { id = dadosRetorno.Id }, dadosRetorno);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult PegarAdocaoPorId(int id)
    {
        var adocao = _adocaoRepository.PegarAdocaoPorId(id);
        return Ok(adocao);
    }

    [Authorize(Roles = "Abrigo")]
    [HttpDelete("{id}")]
    public IActionResult DeletarAdocao(int id)
    {
        _adocaoRepository.DeletarAdocao(id);
        return NoContent();
    }
}
