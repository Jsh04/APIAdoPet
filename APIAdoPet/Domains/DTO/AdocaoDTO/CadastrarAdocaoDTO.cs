using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.AdocaoDTO;

public class CadastrarAdocaoDTO
{

    [Required]
    public string Telefone { get; set; } = String.Empty;
    public string? Mensagem { get; set; }
    [Required]
    public int TutorId { get; set; }
    [Required]
    public string NomePet{ get; set; }
}
