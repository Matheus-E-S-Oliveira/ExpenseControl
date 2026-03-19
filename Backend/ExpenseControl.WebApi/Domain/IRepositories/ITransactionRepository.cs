using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(Guid id);

        Task<IEnumerable<Transaction>> GetAllAsync();

        Task<Transaction> CreateAsync(Guid personId, Guid categoryId, string description, decimal value, TransactionType type);
    }
}
