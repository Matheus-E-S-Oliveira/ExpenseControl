using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de <see cref="Transaction"/>.
    /// Gerencia a persistência de transações financeiras no banco de dados usando <see cref="ExpenseControlContext"/>.
    /// </summary>
    public class TransactionRepository(ExpenseControlContext context) : ITransactionRepository
    {
        /// <summary>
        /// Cria uma nova transação e salva no banco de dados.
        /// </summary>
        /// <param name="personId">Id da pessoa associada à transação.</param>
        /// <param name="categoryId">Id da categoria da transação.</param>
        /// <param name="description">Descrição da transação.</param>
        /// <param name="value">Valor da transação.</param>
        /// <param name="type">Tipo da transação (Despesa ou Receita).</param>
        /// <returns>A transação criada com o Id gerado.</returns>
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

        /// <summary>
        /// Retorna todas as transações cadastradas, incluindo informações de pessoa e categoria.
        /// </summary>
        /// <returns>Lista de transações com objetos relacionados.</returns>
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await context.Transactions
                .Include(x => x.Category)
                .Include(x => x.Person)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna uma transação pelo Id.
        /// </summary>
        /// <param name="id">Id da transação.</param>
        /// <returns>Transação encontrada ou null se não existir.</returns>
        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await context.Transactions.FindAsync(id);
        }
    }
}
