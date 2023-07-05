using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;

namespace APIAdoPet.Infraestrutura.Repository
{
    public class AdocaoRepository : IAdocaoRepository
    {
        private readonly APIAdopetContext _context;

        public AdocaoRepository(APIAdopetContext context)
        {
            _context = context;
        }

        public Adocao CadastrarAdocao(Adocao adocao)
        {
            var adocaoCadastrado = _context.Adocaos.Add(adocao);
            _context.SaveChanges();
            return adocaoCadastrado.Entity;
        }

        void IAdocaoRepository.DeletarAdocao(int id)
        {
            Adocao? adocao = _context.Adocaos.FirstOrDefault(adocao => adocao.Id == id);
            if (adocao != null)
            {
                throw new Exception("Adoção não existe");
            }
            _context.SaveChanges();
        }
    }
}
