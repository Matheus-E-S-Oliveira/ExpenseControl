using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de <see cref="Person"/>.
    /// Gerencia a persistência de pessoas no banco de dados usando <see cref="ExpenseControlContext"/>.
    /// </summary>
    public class PersonRepository(ExpenseControlContext context) : IPersonRepository
    {
        /// <summary>
        /// Cria uma nova pessoa e salva no banco.
        /// </summary>
        /// <param name="name">Nome da pessoa.</param>
        /// <param name="age">Idade da pessoa.</param>
        /// <returns>A pessoa criada com o Id gerado.</returns>
        public async Task<Person> CreateAsync(string name, int age)
        {
            var person = Person.Create(
                name: name,
                age: age);

            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
            return person;
        }

        /// <summary>
        /// Remove uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa a ser removida.</param>
        /// <returns>True se removida, false se não encontrada.</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await  GetByIdAsync(id);

            if (person is null) return false;

            context.Persons.Remove(person);
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas no banco, ordenadas pelo nome.
        /// </summary>
        /// <returns>Lista de pessoas.</returns>
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await context.Persons.OrderBy(x => x.Name).ToListAsync();
        }

        /// <summary>
        /// Retorna uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa.</param>
        /// <returns>Pessoa encontrada ou null se não existir.</returns>
        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await context.Persons.FindAsync(id);
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// </summary>
        /// <param name="id">Id da pessoa.</param>
        /// <param name="name">Novo nome.</param>
        /// <param name="age">Nova idade.</param>
        /// <returns>A pessoa atualizada ou null se não encontrada.</returns>
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
