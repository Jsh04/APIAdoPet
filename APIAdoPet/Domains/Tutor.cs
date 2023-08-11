using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAdoPet.Domains;

public class Tutor
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; } = String.Empty;
    public Endereco? Endereco { get; set; }
    public string? Foto { get; set; } = string.Empty;
    [MaxLength(15)]
    [DefaultValue("")]
    public string? Telefone { get; set; } = String.Empty;
    [Required]
    public string Email { get; set; }


    public virtual Usuario Usuario { get; set; }
}
