﻿using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.PetDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Services.Interfaces;
using AutoMapper;
using Microsoft.OpenApi.Validations;

namespace APIAdoPet.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IAbrigoRepository _abrigoRepository;
    private readonly IMapper _mapper;

    public PetService(IPetRepository petRepository, IAbrigoRepository abrigoRepository, IMapper mapper)
    {
        _petRepository = petRepository;
        _abrigoRepository = abrigoRepository;
        _mapper = mapper;
    }
    public Pet CadastrarPet(CadastrarPetDTO cadastrarPetDTO)
    {
        string abrigoIdUser = cadastrarPetDTO.AbrigoIdUser;
        Abrigo abrigo = _abrigoRepository.PegarAbrigoPorIdUser(abrigoIdUser);
        var pet = _mapper.Map<Pet>(cadastrarPetDTO);
        pet.AbrigoId = abrigo.Id;
        var petCriado = _petRepository.CadastrarPet(pet);
        if (petCriado == null)
            throw new System.Exception("Erro ao cadastrar pet");
        return petCriado;
    }

    public Pet PegarPetPorId(int id)
    {
        var pet = _petRepository.PegarPetPorId(id);
        return pet;
    }

    public Pet AtualizarPet(int id, AtualizarPetDTO atualizarPetDTO)
    {
        var pet = _petRepository.PegarPetPorId(id);
        var abrigo = _abrigoRepository.PegarAbrigoPorIdUser(atualizarPetDTO.AbrigoIdUser);
        var petRequisicao = _mapper.Map(atualizarPetDTO, pet);
        petRequisicao.AbrigoId = abrigo.Id;
        var petAtualizado = _petRepository.AtualizarPet(id, petRequisicao);
        return petAtualizado;
    }

    public Pet PegarPetPeloNome(string nome)
    {
        var pet = _petRepository.PegarPetPeloNome(nome);
        return pet;
    }
}
