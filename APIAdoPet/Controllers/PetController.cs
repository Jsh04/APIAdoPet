using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.PetDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepository;
    private readonly IMapper _mapper;
    private readonly IPetService _petService;
    public PetController(IMapper mapper, IPetRepository petRepository, IPetService petService)
    {
        _mapper = mapper;
        _petRepository = petRepository;
        _petService = petService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult ListarPets(int skip = 0, int take = 10)
    {
        var pets = _petRepository.ListarPets(skip, take);
        return Ok(pets);
    }

    [HttpGet("pets-disponiveis/{abrigoId}")]
    [Authorize("Abrigo")]
    public IActionResult ListarPetaPorAbrigoId(string abrigoId, [FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
       var pets = _petRepository.ListarPetsPorAbrigoId(abrigoId, skip, take);
        return Ok(_mapper.Map<List<ListarPetDTO>>(pets));
    }

    [HttpPost]
    [Authorize("Abrigo")]
    public IActionResult CadastrarPet([FromBody] CadastrarPetDTO petDTO)
    {
        var petCriado = _petService.CadastrarPet(petDTO);
        return CreatedAtAction(nameof(PegarPetPorId), new { id = petCriado.Id }, petCriado);
    }
    

    [HttpGet("{id}")]
    [Authorize("Abrigo")]
    public IActionResult PegarPetPorId(int id)
    {
        var pet = _petRepository.PegarPetPorId(id);
        return Ok(_mapper.Map<ListarPetDTO>(pet));
    }

    [HttpPut("{id}")]
    [Authorize("Abrigo")]
    public IActionResult AtualizarPet(int id, AtualizarPetDTO petDTO)
    {
        var petAtualizado = _petService.AtualizarPet(id, petDTO);
        if (petAtualizado == null) return BadRequest();
        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize("Abrigo")]
    public IActionResult DeletarPet(int id)
    {
        try
        {
            _petRepository.DeletarPet(id);
            return NoContent();
        }
        catch (System.Exception)
        {
            return BadRequest("Pet não encontrado");
        }
    }
   
}
