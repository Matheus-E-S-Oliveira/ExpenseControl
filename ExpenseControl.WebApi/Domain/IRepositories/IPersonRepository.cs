using ExpenseControl.WebApi.Domain.Entities;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    public interface IPersonRepository
    {
        Task<Person?> GetByIdAsync(Guid id);

        Task<IEnumerable<Person>> GetAllAsync();

        Task<Person> CreateAsync(string name, int age);

        Task<Person?> UpdateAsync(Guid id, string name, int age);

        Task<bool>DeleteAsync(Guid id);
    }
}
