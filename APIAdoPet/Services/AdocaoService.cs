
using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Services.Interfaces;

namespace APIAdoPet.Services;

public class AdocaoService : IAdocaoService
{

    private readonly IPetRepository _petRepository;

    public AdocaoService(IPetRepository petRepository)
    {
         _petRepository = petRepository;
    }

    public Pet EncontrarPetPeloNome(string nome)
    {
        var pet  = _petRepository.PegarPetPeloNome(nome);
        return pet;
    }
}
