using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAdoPet.Models;

public class Tutor
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public Endereco? Endereco { get; set; }
    public string Foto { get; set; } = string.Empty;
    [MaxLength(15)]
    [DefaultValue("")]
    public string Telefone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}
