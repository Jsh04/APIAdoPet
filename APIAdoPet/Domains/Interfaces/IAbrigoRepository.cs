namespace APIAdoPet.Domains.Interfaces
{
    public interface IAbrigoRepository
    {
        Abrigo CadastrarAbrigo(Abrigo abrigo);
        void DeletarAbrigo(int id);
        Abrigo AtualizarAbrigo(int id, Abrigo abrigo);
        IEnumerable<Abrigo> ListarAbrigo(int skip, int take);
        Abrigo PegarAbrigoPorId(int id);
    }
}
