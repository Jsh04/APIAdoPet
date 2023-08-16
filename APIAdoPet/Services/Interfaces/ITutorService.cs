using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.TutorDTO;
using Microsoft.AspNetCore.Identity;

namespace APIAdoPet.Services.Interfaces;

public interface ITutorService
{
    Task<Tutor> CadastrarTutor(CadastrarTutorDTO tutorDTO);
    IEnumerable<ListarTutorDTO> ListarTutores(int skip, int take);
    ListarTutorDTO PegarTutorPorId(int id);
    void AtualizarTutorPorId(int id, AtualizaTutorDTO tutorDTO);
    void DeletarTutorPorId(int id);
}
