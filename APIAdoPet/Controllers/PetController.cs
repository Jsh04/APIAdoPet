using APIAdoPet.Domains.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIAdoPet.Controllers;

[ApiController]
[Route("[Controller]")]
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
}
