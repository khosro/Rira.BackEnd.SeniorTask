using Microsoft.EntityFrameworkCore;
using Rira.BackEnd.SeniorTask.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.BackEnd.SeniorTask.RepositoryEFImpl
{
    public class DatabseContext : DbContext
    {
        public DatabseContext(DbContextOptions<DatabseContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.ToTable("Persons");
                    entity.HasKey(t => t.Id);
                    entity.Property(t => t.Id).ValueGeneratedOnAdd();
                });
        }
    }
}
