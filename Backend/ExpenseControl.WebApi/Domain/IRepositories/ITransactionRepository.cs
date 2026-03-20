using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    /// <summary>
    /// Define as operações de persistência de dados para a entidade <see cref="Transaction"/>.
    /// Esta interface segue o padrão Repository, isolando o acesso ao banco de dados.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Obtém uma transação pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da transação.</param>
        /// <returns>A transação correspondente, ou <c>null</c> se não existir.</returns>
        Task<Transaction?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as transações existentes no sistema.
        /// </summary>
        /// <returns>Uma coleção de transações.</returns>
        Task<IEnumerable<Transaction>> GetAllAsync();

        /// <summary>
        /// Cria uma nova transação associada a uma pessoa e a uma categoria.
        /// </summary>
        /// <param name="personId">Id da pessoa que realizou a transação.</param>
        /// <param name="categoryId">Id da categoria da transação.</param>
        /// <param name="description">Descrição da transação.</param>
        /// <param name="value">Valor da transação.</param>
        /// <param name="type">Tipo da transação (<see cref="TransactionType"/>).</param>
        /// <returns>A transação criada.</returns>
        Task<Transaction> CreateAsync(Guid personId, Guid categoryId, string description, decimal value, TransactionType type);
    }
}
