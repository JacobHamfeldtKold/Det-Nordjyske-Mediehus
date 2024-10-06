using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NordjyskeMediehus.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        Task<int> Add(T entity);
    }
}
