using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains;

public class Pet
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Required]
    public bool Adotado { get; set; } = false;
    [Required]
    public string Idade { get; set; }
    [Required]
    public Endereco Endereco { get; set; }
    [Required]
    public string Imagem { get; set; }
    [Required]
    public int AbrigoId { get; set; }
    public virtual Abrigo Abrigo { get; set; }

    public void FoiAdotado()
    {
        this.Adotado = true;
    }
}
