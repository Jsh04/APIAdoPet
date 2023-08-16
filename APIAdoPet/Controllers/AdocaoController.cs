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
public class AdocaoController : ControllerBase
{
    private readonly IAdocaoRepository _adocaoRepository;
    private readonly IAdocaoService _adocaoService;
    private readonly IMapper _mapper;

    public AdocaoController(IAdocaoRepository adocaoRepository, IMapper mapper, IAdocaoService adocaoService)
    {
        _adocaoService = adocaoService;
        _adocaoRepository = adocaoRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarAdocao(CadastrarAdocaoDTO adocaoDTO)
    {
        Adocao adocao = _mapper.Map<Adocao>(adocaoDTO);
        Pet pet = _adocaoService.EncontrarPetPeloNome(adocaoDTO.NomePet);
        adocao.PetId = pet.Id;
        pet.FoiAdotado();
        var adocaoCadastrado = _adocaoRepository.CadastrarAdocao(adocao);
        var dadosRetorno = _mapper.Map<DadosDetalhamentoAdocaoDTO>(adocao);
        return CreatedAtAction(nameof(PegarAdocaoPorId), new { id = adocao.Id }, dadosRetorno);
    }

    [HttpGet("{id}")]
    public IActionResult PegarAdocaoPorId(int id)
    {
        var adocao = _adocaoRepository.PegarAdocaoPorId(id);
        return Ok(adocao);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAdocao(int id)
    {
        _adocaoRepository.DeletarAdocao(id);
        return NoContent();
    }
}
