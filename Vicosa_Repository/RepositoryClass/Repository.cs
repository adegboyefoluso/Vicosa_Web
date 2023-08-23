using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vicosa_Entity;
using Vicosa_Repository.Interface;

namespace Vicosa_Repository.RepositoryClass
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly VicosaContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(VicosaContext context)
        {
                _context = context;
            this._dbSet = _context.Set<T>();

        }

        public void Add(T item)
        {
           _dbSet.Add(item);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

      
    }
}
