using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.TutorDTO;

public class CadastrarTutorDTO
{
    [Required]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
    [Required]
    [Compare("Senha", ErrorMessage = "Senha inválida")]
    public string SenhaConfirmada { get; set; }
}
