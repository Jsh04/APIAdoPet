using APIAdoPet.Domains;

namespace APIAdoPet.Services.Interfaces;

public interface IAdocaoService
{
    Pet EncontrarPetPeloNome(string nome);
}
