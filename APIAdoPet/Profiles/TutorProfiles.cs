using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Models;
using AutoMapper;

namespace APIAdoPet.Profiles
{
    public class TutorProfiles : Profile
    {
        public TutorProfiles()
        {
            CreateMap<CadastrarTutorDTO, Tutor>();
            CreateMap<AtualizaTutorDTO, Tutor>();
            CreateMap<Tutor, ListarTutorDTO>();
        }
    }
}
