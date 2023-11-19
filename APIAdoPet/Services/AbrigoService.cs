using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;
using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains.Enums;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Services.Interfaces;
using APIAdoPet.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAdoPet.Services;

public class AbrigoService : IAbrigoService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAbrigoRepository _abrigoRepository;

    public AbrigoService(IMapper mapper, 
        UserManager<Usuario> userManager,
        RoleManager<IdentityRole> roleManager,
        IAbrigoRepository abrigoRepository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        _abrigoRepository = abrigoRepository;
    }

    public async Task<DadosDetalhamentoAbrigo> CadastrarAbrigo(CadastrarAbrigoDTO abrigoDTO)
    {
        var usuario = RetornarUsuarioObj(abrigoDTO);
        var abrigo = _mapper.Map<Abrigo>(abrigoDTO);
        abrigo.Usuario = usuario;
        var resultado =  await _userManager.CreateAsync(usuario, abrigoDTO.Senha);

        if (!resultado.Succeeded)
            throw new System.Exception("Credencias inválidas");

        await CriarRole(Roles.Abrigo.ToString());

        _abrigoRepository.CadastrarAbrigo(abrigo);

        await _userManager.AddToRoleAsync(usuario, Roles.Abrigo.ToString());

        var dadosDetalhamentoAbrigo = _mapper.Map<DadosDetalhamentoAbrigo>(abrigo);
        return dadosDetalhamentoAbrigo;

    }

    private async Task CriarRole(string roleName)
    {
        if (await _roleManager.FindByNameAsync(roleName) == null)
            await _roleManager.CreateAsync(new IdentityRole(roleName));
    }

    private Usuario RetornarUsuarioObj(CadastrarAbrigoDTO abrigoDTO)
    {

        var nomeFormatado = FormatUtil.RetirarCaracteresEspecias(abrigoDTO.Name);
        return new Usuario()
        {
            UserName = nomeFormatado.Replace(" ", ""),
            Email = abrigoDTO.Email,

        }; ;
    }
}
