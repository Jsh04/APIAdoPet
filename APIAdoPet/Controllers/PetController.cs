using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.PetDTO;
using APIAdoPet.Domains.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepository;
    private readonly IMapper _mapper;

    public PetController(IMapper mapper, IPetRepository petRepository)
    {
        _mapper = mapper;
        _petRepository = petRepository;
    }

    [HttpGet]
    public IActionResult ListarPets(int skip = 0, int take = 10)
    {
        var pets = _petRepository.ListarPets(skip, take);
        return Ok(pets);
    }

    [HttpPost]
    public IActionResult CadastrarPet([FromBody] CadastrarPetDTO petDTO)
    {
        var pet = _mapper.Map<Pet>(petDTO);
        Pet petCriado = _petRepository.CadastrarPet(pet);
        return CreatedAtAction(nameof(PegarPetPorId), new { id = petCriado.Id }, petCriado);
    }
    

    [HttpGet("{id}")]
    public IActionResult PegarPetPorId(int id)
    {
        var pet = _petRepository.PegarPetPorId(id);
        return Ok(_mapper.Map<ListarPetDTO>(pet));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarPet(int id, AtualizarPetDTO petDTO)
    {
        var pet = _petRepository.PegarPetPorId(id);
        var petRequisicao = _mapper.Map(petDTO, pet);
        var petAtualizado  = _petRepository.AtualizarPet(id, petRequisicao);
        if (petAtualizado == null) return BadRequest();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletarPet(int id)
    {
        try
        {
            _petRepository.DeletarPet(id);
            return NoContent();

        }
        catch (System.Exception e)
        {
            return BadRequest("Pet não encontrado");
        }
    }
   
}
