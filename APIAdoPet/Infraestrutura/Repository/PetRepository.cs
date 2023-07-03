using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;

namespace APIAdoPet.Infraestrutura.Repository;

public class PetRepository : IPetRepository
{
    public Pet AtualizarPet(int id, Pet pet)
    {
        throw new NotImplementedException();
    }

    public Pet CadastrarPet(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void DeletarPet(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> ListarPets(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Pet PegarPetPorId(int id)
    {
        throw new NotImplementedException();
    }
}
