using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Models.DTO
{
    public class ListarTutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
