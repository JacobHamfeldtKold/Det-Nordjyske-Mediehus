using Microsoft.EntityFrameworkCore;
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

        public async Task<T> GetById(int id) 
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
