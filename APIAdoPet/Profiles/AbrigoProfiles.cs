using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Models;
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
