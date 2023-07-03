using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIAdoPet.Domains.DTO.PetDTO;

public class ListarPetDTO
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public bool Adotado { get; set; }

    public string Idade { get; set; }

    public Endereco Endereco { get; set; }

    public string Imagem { get; set; }
    [JsonPropertyName("abrigos_id")]
    public int AbrigoId { get; set; }
}
