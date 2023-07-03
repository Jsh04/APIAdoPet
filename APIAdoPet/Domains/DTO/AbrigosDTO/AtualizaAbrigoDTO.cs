using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using APIAdoPet.Domains;

namespace APIAdoPet.Domains.DTO.AbrigosDTO
{
    public class AtualizaAbrigoDTO
    {
        [MinLength(3)]
        public string Name { get; set; }
        [EmailAddress]
        [MinLength(10)]
        public string Email { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        public string Senha { get; set; }
    }
}
