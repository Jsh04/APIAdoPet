using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.AbrigosDTO;

public class DadosDetalhamentoAbrigo
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }
    public Endereco Endereco { get; set; }
}
