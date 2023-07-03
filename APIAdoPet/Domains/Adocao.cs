﻿using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains;

public class Adocao
{
    [Key]
    [Required]
    public int Id { get; private set; }
    [Required]
    public string Telefone { get; set; } = String.Empty;
    public string? Mensagem { get; set; }
    [Required]
    public int TutorId { get; set; }
    public virtual ICollection<Pet> Pets { get; set; }
    public virtual Tutor Tutor { get; set; }
}
