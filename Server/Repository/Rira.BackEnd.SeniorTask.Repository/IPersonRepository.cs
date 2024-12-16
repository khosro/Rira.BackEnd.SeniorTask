using Rira.BackEnd.SeniorTask.Dtos;
using Rira.BackEnd.SeniorTask.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.BackEnd.SeniorTask.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(long id);
        public Task CreateAsync(Person person);
        public Task UpdateAsync(Person person);
        Task<List<Person>> GetAllAsync();
        Task DeleteAsync(long id);
    }
}
