using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.TutorDTO;
using APIAdoPet.Domains.Enums;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Exception;
using APIAdoPet.Services.Interfaces;
using APIAdoPet.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text.RegularExpressions;

namespace APIAdoPet.Services;

public class TutorService : ITutorService
{
    private readonly UserManager<Usuario> _userManager;

    private readonly ITutorRepository _tutorRepository;

    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly IMapper _mapper;

    public TutorService(ITutorRepository tutorRepository, 
        IMapper mapper, 
        RoleManager<IdentityRole> roleManager,
        UserManager<Usuario> userManager
        )
    {
        _tutorRepository = tutorRepository;
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ListarTutorDTO> CadastrarTutor(CadastrarTutorDTO tutorDTO)
    {
        var usuario = RetornarUsuarioObj(tutorDTO);
        var tutor = _mapper.Map<Tutor>(tutorDTO);
        tutor.Usuario = usuario;   
        var resultado = await _userManager.CreateAsync(usuario, tutorDTO.Senha);
        if (!resultado.Succeeded)
            throw new System.Exception("Credencias Inválidas");
        await CriarRole(Roles.Tutor.ToString());
        _tutorRepository.CadastrarTutor(tutor);
        await _userManager.AddToRoleAsync(usuario, Roles.Tutor.ToString());
        var tutorDTOCriado = _mapper.Map<ListarTutorDTO>(tutor);
        return tutorDTOCriado;
    }

    public IEnumerable<ListarTutorDTO> ListarTutores(int skip, int take)
    {
       return _mapper.Map<List<ListarTutorDTO>>(_tutorRepository.ListarTutor(skip, take));
    }

    public ListarTutorDTO PegarTutorPorId(int id)
    {
        var tutor = _tutorRepository.PegarTutorPorId(id);
        if (tutor == null)
            throw new HttpResponseException(404, "Tutor não encontrado");
        var tutorDTO = _mapper.Map<ListarTutorDTO>(tutor);
        return tutorDTO;

    }

    public void AtualizarTutorPorId(int id, AtualizaTutorDTO tutorDTO)
    {
        var tutor = _tutorRepository.PegarTutorPorId(id);
        if (tutor == null) 
            throw new HttpResponseException(404, "Tutor não encontrado");
        var tutorRequisicao = _mapper.Map(tutorDTO, tutor);
        _tutorRepository.AtualizarTutor(id, tutorRequisicao);
    }

    public void DeletarTutorPorId(int id)
    {
        try
        {
            _tutorRepository.DeletarTutor(id);
        }catch(System.Exception ex)
        {
            throw new HttpResponseException(404, ex.Message);
        }
       
    }

    private static Usuario RetornarUsuarioObj(CadastrarTutorDTO tutorDTO)
    {

        var nomeFormatado = FormatUtil.RetirarCaracteresEspecias(tutorDTO.Nome);
        return new Usuario()
        {
            UserName = nomeFormatado.Replace(" ", "_"),
            Email = tutorDTO.Email,

        }; ;
    }
    private async Task CriarRole(string roleName)
    {
        if(await _roleManager.FindByNameAsync(roleName) == null)
            await _roleManager.CreateAsync(new IdentityRole(roleName));
    }

    
}
