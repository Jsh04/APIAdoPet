using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.AdocaoDTO;

public class CadastrarAdocaoDTO
{

    [Required]
    public string Telefone { get; set; } = String.Empty;

    public string? Mensagem { get; set; }

    [Required]
    public string TutorIdUser { get; set; }

    [Required]
    public int PetId { get; set; }
}
