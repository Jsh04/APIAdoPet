using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;

namespace APIAdoPet.Infraestrutura.Repository;

public class PetRepository : IPetRepository
{
    private readonly APIAdopetContext _context;

    public PetRepository(APIAdopetContext context)
    {
        _context = context;
    }

    public Pet AtualizarPet(int id, Pet pet)
    {
        var petAtualizado = _context.Pets.Update(pet);
        _context.SaveChanges();
        return petAtualizado.Entity;
    }

    public Pet CadastrarPet(Pet pet)
    {
        var petCriado = _context.Pets.Add(pet);
        _context.SaveChanges();
        return petCriado.Entity;
    }

    public void DeletarPet(int id)
    {
        var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if (pet == null) throw new Exception("Pet não existe"); 
        _context.Pets.Remove(pet);
        _context.SaveChanges();
    }

    public IEnumerable<Pet> ListarPets(int skip, int take)
    {
        return _context.Pets.Skip(skip).Take(take).ToList();
    }

    public Pet PegarPetPorId(int id)
    {
        var pet =  _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if(pet == null) throw new Exception("Pet não existe");
        return pet;
    }
}
