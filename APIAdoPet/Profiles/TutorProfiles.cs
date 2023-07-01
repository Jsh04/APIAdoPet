using APIAdoPet.Models;
using APIAdoPet.Models.DTO;
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
