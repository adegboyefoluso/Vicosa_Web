
using Vicosa_Entity;
using Vicosa_Repository.Interface;

namespace Vicosa_Repository.RepositoryClass
{
    public class AlumnusRepository : Repository<Alumnus>, IAlumnus
    {
        private readonly VicosaContext _context;
        public AlumnusRepository( VicosaContext vicosaContext) : base(vicosaContext) 
        {
                _context = vicosaContext;
        }
        public int SaveChanges()
        {
           return  _context.SaveChanges();
        }

        public void UpdateAlumnus(Alumnus alumnus)
        {
          _context.Update(alumnus);
        }
    }
}
