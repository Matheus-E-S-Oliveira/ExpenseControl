using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    /// <summary>
    /// Representa os dados de uma transação para respostas da API.
    /// </summary>
    public class TransactionResponse
    {
        /// <summary>
        /// Identificador único da transação.
        /// </summary>
        public Guid Id { get; init; }

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

        /// <summary>
        /// Dados da pessoa associada à transação.
        /// </summary>
        public PersonResponse? Person { get; init; }

        /// <summary>
        /// Dados da categoria associada à transação.
        /// </summary>
        public CategoryResponse? Category { get; init; }

        /// <summary>
        /// Converte uma entidade <see cref="Transaction"/> em <see cref="TransactionResponse"/>.
        /// </summary>
        /// <param name="transaction">Entidade transação a ser mapeada.</param>
        /// <returns>Instância de <see cref="TransactionResponse"/> correspondente.</returns>
        public static TransactionResponse Map(Transaction transaction)
        {
            return new TransactionResponse
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Type = transaction.Type,
                Person = transaction.Person is not null ? PersonResponse.Map(transaction.Person) : null,
                Category = transaction.Category is not null ? CategoryResponse.Map(transaction.Category) : null,
            };
        }

        /// <summary>
        /// Converte uma lista de entidades <see cref="Transaction"/> em uma lista de <see cref="TransactionResponse"/>.
        /// </summary>
        /// <param name="transactions">Lista de entidades transação.</param>
        /// <returns>Lista de <see cref="TransactionResponse"/>.</returns>
        public static IEnumerable<TransactionResponse> MapList(IEnumerable<Transaction> transactions)
        {
            return transactions.Select(Map);
        }
    }
}
