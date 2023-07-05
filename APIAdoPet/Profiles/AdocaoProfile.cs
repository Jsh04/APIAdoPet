using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AdocaoDTO;
using AutoMapper;

namespace APIAdoPet.Profiles
{
    public class AdocaoProfile : Profile
    {
        public AdocaoProfile()
        {
            CreateMap<CadastrarAdocaoDTO, Adocao>();
            CreateMap<Adocao, DadosDetalhamentoAdocaoDTO>();
        }
    }
}
