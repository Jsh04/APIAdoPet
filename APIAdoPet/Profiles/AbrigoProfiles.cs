using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains;
using AutoMapper;

namespace APIAdoPet.Profiles
{
    public class AbrigoProfiles : Profile
    {
        public AbrigoProfiles()
        {
            CreateMap<CadastrarAbrigoDTO, Abrigo>();
            CreateMap<Abrigo, DadosDetalhamentoAbrigo>();
            CreateMap<AtualizaAbrigoDTO, Abrigo>();
        }
    }
}
