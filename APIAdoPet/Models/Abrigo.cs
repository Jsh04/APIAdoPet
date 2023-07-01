using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Models;

public class Abrigo
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo nome é obrigatório")]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    [MinLength(10)]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
    [Required]
    public Endereco Endereco { get; set; }

}
