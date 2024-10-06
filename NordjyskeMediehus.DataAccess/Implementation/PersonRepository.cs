using NordjyskeMediehus.DataAccess.Context;
using NordjyskeMediehus.Domain.Entities;
using NordjyskeMediehus.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordjyskeMediehus.DataAccess.Implementation
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(NordjyskeMediehusDbContext context) : base (context)
        {
            
        }
    }
}
