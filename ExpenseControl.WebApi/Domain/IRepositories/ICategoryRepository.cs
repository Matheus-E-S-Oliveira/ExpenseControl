using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> CreateAsync(string description, CategoryPurpose purpose);

    }
}
