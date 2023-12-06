using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AdocaoDTO;

namespace APIAdoPet.Services.Interfaces;

public interface IAdocaoService
{
    Pet EncontrarPetPeloNome(string nome);
    DadosDetalhamentoAdocaoDTO CadastrarAdocao(CadastrarAdocaoDTO cadastrarAdocao);
}
