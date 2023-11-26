using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.UsuarioDTO;

public class UsuarioRetornarDTO
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Role { get; set; }
}
