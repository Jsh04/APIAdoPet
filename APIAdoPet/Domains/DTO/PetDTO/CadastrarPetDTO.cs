using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIAdoPet.Domains.DTO.PetDTO;

public class CadastrarPetDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Campo deverá conter mais de 3 caracteres")]
    public string Nome { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Required]
    public bool Adotado { get; set; }
    [Required]
    public string Idade { get; set; }
    [Required]
    public Endereco Endereco { get; set; }
    [Required]
    public string Imagem { get; set; }
    [Required]
    [JsonPropertyName("abrigos_id")]
    public int AbrigoId { get; set; }
}
