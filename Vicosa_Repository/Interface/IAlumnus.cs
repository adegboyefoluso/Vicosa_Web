using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicosa_Entity;

namespace Vicosa_Repository.Interface
{
   public interface IAlumnus:IRepository<Alumnus>
    {
        void UpdateAlumnus(Alumnus alumnus);
        int SaveChanges();
    }
}
