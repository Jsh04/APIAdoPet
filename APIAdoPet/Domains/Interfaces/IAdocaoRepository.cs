namespace APIAdoPet.Domains.Interfaces;

public interface IAdocaoRepository
{
    Adocao CadastrarAdocao(Adocao adocao);
    void DeletarAdocao(int id);
}
