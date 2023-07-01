using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Models.DTO;

public class CadastrarTutorDTO
{
    [Required]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}
