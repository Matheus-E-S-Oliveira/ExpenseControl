using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    public class TransactionRepository(ExpenseControlContext context) : ITransactionRepository
    {
        public async Task<Transaction> CreateAsync(Guid personId, Guid categoryId, string description, decimal value, TransactionType type)
        {
            var transaction = Transaction.Create(
                personId: personId,
                categoryId: categoryId,
                description: description,
                value: value,
                type: type);

            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await context.Transactions
                .Include(x => x.Category)
                .Include(x => x.Person)
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await context.Transactions.FindAsync(id);
        }
    }
}
