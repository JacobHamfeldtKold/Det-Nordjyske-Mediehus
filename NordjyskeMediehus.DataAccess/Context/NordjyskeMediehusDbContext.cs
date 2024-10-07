using Microsoft.EntityFrameworkCore;
using NordjyskeMediehus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordjyskeMediehus.DataAccess.Context
{
    public class NordjyskeMediehusDbContext : DbContext
    {
        public NordjyskeMediehusDbContext(DbContextOptions<NordjyskeMediehusDbContext> options) : base (options)
        {          
        }

        public DbSet<Person> people { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person {Id = 1, firstName = "Jacob", lastName = "Hamfeldt Kold", phoneNumber = "42791739"}
                );
        }

    }
}
