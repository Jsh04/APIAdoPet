using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.PetDTO;

namespace APIAdoPet.Services.Interfaces;

public interface IPetService
{
    Pet CadastrarPet(CadastrarPetDTO cadastrarPetDTO);
    Pet AtualizarPet(int id, AtualizarPetDTO atualizarPetDTO);
}
