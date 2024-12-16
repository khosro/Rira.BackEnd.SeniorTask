using Microsoft.EntityFrameworkCore;
using Rira.BackEnd.SeniorTask.Dtos;
using Rira.BackEnd.SeniorTask.Entity;
using Rira.BackEnd.SeniorTask.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.BackEnd.SeniorTask.RepositoryEFImpl
{
    public class PersonEFRepository : IPersonRepository
    {
        private DatabseContext _databseContext { get; set; }

        public PersonEFRepository(DatabseContext databseContext)
        {
            _databseContext = databseContext;
        }

        public async Task<Person> GetByIdAsync(long id)
        {
            return await _databseContext.Persons.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task CreateAsync(Entity.Person person)
        {
            await _databseContext.Persons.AddAsync(person);
            await _databseContext.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _databseContext.Persons.ToListAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _databseContext.Persons.Entry(person).State = EntityState.Modified;
            await _databseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var person = await GetByIdAsync(id);
            _databseContext.Persons.Remove(person);
            await _databseContext.SaveChangesAsync();
        }
    }
}
