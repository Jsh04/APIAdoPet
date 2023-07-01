using APIAdoPet.Models;
using APIAdoPet.Models.DTO;
using AutoMapper;

namespace APIAdoPet
{
    public class TutorProfile : Profile
    {
        public TutorProfile()
        {
            CreateMap<CadastrarTutorDTO, Tutor>();
            CreateMap<Tutor, ListarTutorDTO>();
            CreateMap<AtualizaTutorDTO, Tutor>();

        }

    }
}
