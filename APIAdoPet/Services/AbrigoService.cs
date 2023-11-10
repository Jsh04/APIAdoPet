using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Services.Interfaces;
using APIAdoPet.Utils;
using AutoMapper;

namespace APIAdoPet.Services;

public class AbrigoService : IAbrigoService
{
    private readonly IMapper _mapper;

    public AbrigoService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Abrigo> CadastrarAbrigoDTO(CadastrarAbrigoDTO abrigoDTO)
    {
        var usuario = RetornarUsuarioObj(abrigoDTO);
        var abrigo = _mapper.Map<Abrigo>(abrigoDTO);
        abrigo.Usuario = usuario;
        return abrigo;

    }

    private Usuario RetornarUsuarioObj(CadastrarAbrigoDTO abrigoDTO)
    {

        var nomeFormatado = FormatUtil.RetirarCaracteresEspecias(abrigoDTO.Name);
        return new Usuario()
        {
            UserName = nomeFormatado.Replace(" ", "_"),
            Email = abrigoDTO.Email,

        }; ;
    }
}
