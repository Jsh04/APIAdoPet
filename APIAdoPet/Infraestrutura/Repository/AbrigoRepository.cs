﻿using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;

namespace APIAdoPet.Infraestrutura.Repository;

public class AbrigoRepository : IAbrigoRepository
{
    private readonly APIAdopetContext _context;

    public AbrigoRepository(APIAdopetContext context)
    {
        _context = context;
    }

    public Abrigo AtualizarAbrigo(int id, Abrigo abrigo)
    {
        var abrigoAtualizado = _context.Abrigo.Update(abrigo);
        _context.SaveChanges();
        return abrigoAtualizado.Entity;
    }

    public Abrigo CadastrarAbrigo(Abrigo abrigo)
    {
        var abrigoCriado = _context.Abrigo.Add(abrigo);
        _context.SaveChanges();
        return abrigoCriado.Entity;
    }

    public void DeletarAbrigo(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);
        if (abrigo != null)
        {
            _context.Abrigo.Remove(abrigo);
            _context.SaveChanges();
            return;
        }
        throw new System.Exception("Abrigo não encontrado");
    }

    public IEnumerable<Abrigo> ListarAbrigo(int skip = 0, int take = 10)
    {
        var abrigos = _context.Abrigo.Skip(skip).Take(take);
        return abrigos.ToList();
    }

    public Abrigo PegarAbrigoPorId(int id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Id == id);
        if (abrigo != null)
        {
            return abrigo;
        }
        throw new System.Exception("Abrigo não encontrado");
    }

    public Abrigo PegarAbrigoPorIdUser(string id)
    {
        var abrigo = _context.Abrigo.FirstOrDefault(abrigo => abrigo.Usuario.Id ==  id);
        if (abrigo != null)
            return abrigo;
        
        throw new System.Exception("Abrigo não encontrado");
    }
}
