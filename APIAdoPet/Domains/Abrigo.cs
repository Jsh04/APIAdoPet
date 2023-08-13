using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains;

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
    public Endereco Endereco { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }

    public virtual Usuario Usuario { get; set; }


}
