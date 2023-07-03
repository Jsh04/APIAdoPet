using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.PetDTO;
using AutoMapper;

namespace APIAdoPet.Profiles;

public class PetProfile : Profile
{
	public PetProfile()
	{
		CreateMap<CadastrarPetDTO, Pet>();
		CreateMap<Pet, ListarPetDTO>();
	}
}
