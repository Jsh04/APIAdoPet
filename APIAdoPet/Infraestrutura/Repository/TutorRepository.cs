using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;

namespace APIAdoPet.Infraestrutura.Repository
{
    public class TutorRepository : ITutorRepository 
    
    {
        private readonly APIAdopetContext _context;

        public TutorRepository(APIAdopetContext context)
        {
            _context = context;
        }

        public Tutor AtualizarTutor(int id, Tutor tutor)
        {
            var tutorAtualizado = _context.Tutores.Update(tutor);
            _context.SaveChanges();
            return tutorAtualizado.Entity;
        }

        public Tutor CadastrarTutor(Tutor tutor)
        {
            var tutorCriado = _context.Tutores.Add(tutor);
            _context.SaveChanges();
            return tutorCriado.Entity;
        }

        public void DeletarTutor(int id)
        {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor != null)
            {
                _context.Tutores.Remove(tutor);
                _context.SaveChanges();
                return;
            }
            throw new Exception("Tutor não encontrado");
        }

        public IEnumerable<Tutor> ListarTutor(int skip = 0, int take = 10)
        {
            var tutores = _context.Tutores.Skip(skip).Take(take);
            return tutores.ToList();
        }

        public Tutor PegarTutorPorId(int id)
        {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if(tutor != null)
            {
                return tutor;
            }
            throw new Exception("Tutor não encontrado");
        }
    }
}
