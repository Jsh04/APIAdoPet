using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

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
        if (pet == null) throw new System.Exception("Pet não existe"); 
        _context.Pets.Remove(pet);
        _context.SaveChanges();
    }

    public IEnumerable<Pet> ListarPets(int skip, int take)
    {
        return _context.Pets.Include(pet => pet.Abrigo).Skip(skip).Take(take).Where(pet => !pet.Adotado).ToList();
    }

    public Pet PegarPetPorId(int id)
    {
        var pet =  _context.Pets.FirstOrDefault(pet => pet.Id == id);
        if(pet == null) throw new System.Exception("Pet não existe");
        return pet;
    }

    public Pet PegarPetPeloNome(string nome)
    {
       var pet = _context.Pets.FirstOrDefault(pet => pet.Nome.Equals(nome));
        if (pet == null) throw new System.Exception("Pet Não encontrado");
        return pet;
    }

    public IEnumerable<Pet> ListarPetsPorAbrigoId(string abrigoId, int skip, int take)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Usuario.Id == abrigoId);
        if (abrigo == null)
            throw new System.Exception("Abrigo não encontrado");
            
        var petsPorAbrigo = _context.Pets.Where(pet => pet.AbrigoId == abrigo.Id).Skip(skip).Take(take).ToList();
        return petsPorAbrigo;
    }
}
