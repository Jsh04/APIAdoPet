using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains;
using AutoMapper;
using APIAdoPet.Domains.DTO;

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
