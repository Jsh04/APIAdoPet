using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.AbrigosDTO;

namespace APIAdoPet.Services.Interfaces;

public interface IAbrigoService
{
    Task<DadosDetalhamentoAbrigo> CadastrarAbrigo(CadastrarAbrigoDTO abrigoDTO);
}
