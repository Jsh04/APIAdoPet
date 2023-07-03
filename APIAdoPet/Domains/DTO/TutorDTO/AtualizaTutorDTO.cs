using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using APIAdoPet.Domains.DTO.TutorDTO;

namespace APIAdoPet.Domains.DTO
{
    public class AtualizaTutorDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        [MaxLength(15)]
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Foto { get; set; }
    }
}
