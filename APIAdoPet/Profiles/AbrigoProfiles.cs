using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using AutoMapper;

namespace APIAdoPet.Profiles
{
    public class AbrigoProfiles : Profile
    {
        public AbrigoProfiles()
        {
            CreateMap<CadastrarAbrigoDTO, Abrigo>();
            CreateMap<Abrigo, DadosDetalhamentoAbrigo>();
        }
    }
}
