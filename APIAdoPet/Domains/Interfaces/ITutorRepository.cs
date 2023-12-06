namespace APIAdoPet.Domains.Interfaces;
public interface ITutorRepository
{
    Tutor CadastrarTutor(Tutor tutor);
    void DeletarTutor(int id);
    Tutor AtualizarTutor(int id, Tutor tutor);
    IEnumerable<Tutor> ListarTutor(int skip, int take);
    Tutor PegarTutorPorId(int id);
    Tutor PegarTutorPorIdUser(string id);
}
