namespace APIAdoPet.Domains.Interfaces;

public interface IPetRepository
{
    Pet CadastrarPet(Pet pet);
    void DeletarPet(int id);
    Pet AtualizarPet(int id, Pet pet);
    IEnumerable<Pet> ListarPets(int skip, int take);
    Pet PegarPetPorId(int id);
}
