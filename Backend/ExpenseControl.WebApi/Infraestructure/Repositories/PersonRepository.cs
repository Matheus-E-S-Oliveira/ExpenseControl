using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    public class PersonRepository(ExpenseControlContext context) : IPersonRepository
    {
        public async Task<Person> CreateAsync(string name, int age)
        {
            var person = Person.Create(
                name: name,
                age: age);

            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await  GetByIdAsync(id);

            if (person is null) return false;

            context.Persons.Remove(person);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await context.Persons.FindAsync(id);
        }

        public async Task<Person?> UpdateAsync(Guid id, string name, int age)
        {
            var person = await GetByIdAsync(id);

            if (person is null) return null;

            var personUpdate = person.Update(
                name: name,
                age: age);

            context.Persons.Update(personUpdate);
            await context.SaveChangesAsync();

            return person;
        }
    }
}
