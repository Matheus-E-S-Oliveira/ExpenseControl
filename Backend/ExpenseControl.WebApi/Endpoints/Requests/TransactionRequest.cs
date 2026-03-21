using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Requests
{
    /// <summary>
    /// Representa os dados necessários para criar uma transação.
    /// </summary>
    public class TransactionRequest
    {
        /// <summary>
        /// Id da pessoa responsável pela transação.
        /// </summary>
        public Guid PersonId { get; init; }

        /// <summary>
        /// Id da categoria associada à transação.
        /// </summary>
        public Guid CategoryId { get; init; }

        /// <summary>
        /// Descrição da transação.
        /// </summary>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Valor da transação.
        /// </summary>
        public decimal Value { get; init; }

        /// <summary>
        /// Tipo da transação (Despesa ou Receita).
        /// </summary>
        public TransactionType Type { get; init; }
    }
}
