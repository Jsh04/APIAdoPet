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

        public void AtualizarTutor(int id, Tutor tutor)
        {
            _context.Tutores.Update(tutor);
        }

        public Tutor CadastrarTutor(Tutor tutor)
        {
            var tutorCriado = _context.Tutores.Add(tutor);
            _context.SaveChanges();
            return tutorCriado;
        }

        public void DeletarTutor(int id)
        {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            _context.Tutores.Remove(tutor);
        }

        public IEnumerable<Tutor> ListarTutor(int skip = 0, int take = 10)
        {
            var tutores = _context.Tutores.Skip(skip).Take(take);
            return (IEnumerable<Tutor>)tutores.ToList();
        }
    }
}
