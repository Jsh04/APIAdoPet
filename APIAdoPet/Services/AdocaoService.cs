
using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AdocaoDTO;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Infraestrutura.Repository;
using APIAdoPet.Services.Interfaces;
using AutoMapper;

namespace APIAdoPet.Services;

public class AdocaoService : IAdocaoService
{
    private readonly IMapper _mapper;
    private readonly IPetService _petService;
    private readonly ITutorService _tutorService;
    private readonly IAdocaoRepository _adocaoRepository;

    public AdocaoService(IPetService petService, 
        ITutorService tutorService, 
        IMapper mapper,
        IAdocaoRepository adocaoRepository)
    {
        _petService = petService;
        _tutorService = tutorService;
        _mapper = mapper;
        _adocaoRepository  = adocaoRepository;
    }
    
    public DadosDetalhamentoAdocaoDTO CadastrarAdocao(CadastrarAdocaoDTO cadastrarAdocao)
    {
        var tutor = _tutorService.PegarTutorPeloIdUser(cadastrarAdocao.TutorIdUser);
        Pet pet = _petService.PegarPetPorId(cadastrarAdocao.PetId);
        
        Adocao adocao = _mapper.Map<Adocao>(cadastrarAdocao);
        adocao.TutorId = tutor.Id;
        adocao.PetId = pet.Id;

        pet.FoiAdotado();
        var adocaoCadastrado = _adocaoRepository.CadastrarAdocao(adocao);

        var dadosRetorno = _mapper.Map<DadosDetalhamentoAdocaoDTO>(adocao);
        return dadosRetorno;
    }

    public Pet EncontrarPetPeloNome(string nome)
    {
        throw new NotImplementedException();
    }
}
