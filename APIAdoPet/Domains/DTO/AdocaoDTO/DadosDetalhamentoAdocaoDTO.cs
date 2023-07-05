using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.AdocaoDTO;

public class DadosDetalhamentoAdocaoDTO
{

    public int Id { get; private set; }

    public DateTime Data { get; set; } = DateTime.UtcNow;

    public int TutorId { get; set; }
    public int PetId { get; set; }
}
