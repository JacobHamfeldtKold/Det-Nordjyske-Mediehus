using NordjyskeMediehus.DataAccess.Context;
using NordjyskeMediehus.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordjyskeMediehus.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly NordjyskeMediehusDbContext _context;
        public GenericRepository(NordjyskeMediehusDbContext context)
        {
            _context = context;
        }

        public T GetById(int id) 
        {
            return _context.Set<T>().Find(id);
        }

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
