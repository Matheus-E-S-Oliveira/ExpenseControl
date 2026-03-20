using ExpenseControl.WebApi.Domain.Enums;
using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    /// <summary>
    /// Representa uma transação financeira no sistema de controle de gastos residenciais.
    /// Cada transação está associada a uma pessoa e a uma categoria, podendo ser do tipo Receita ou Despesa.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Identificador único da transação.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Descrição da transação (ex: "Compra de supermercado", "Salário mensal").
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Valor da transação.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Tipo da transação (Receita ou Despesa).
        /// </summary>
        public TransactionType Type { get; private set; }

        /// <summary>
        /// Data e hora de criação da transação (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Data e hora da última atualização da transação (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Identificador da pessoa associada a esta transação.
        /// </summary>
        public Guid PersonId { get; private set; }

        /// <summary>
        /// Pessoa associada a esta transação.
        /// Usado para navegação no Entity Framework.
        /// Não é serializado em JSON para evitar referência circular.
        /// </summary>
        [JsonIgnore]
        public virtual Person? Person { get; private set; }

        /// <summary>
        /// Identificador da categoria associada a esta transação.
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Categoria associada a esta transação.
        /// Usado para navegação no Entity Framework.
        /// Não é serializado em JSON para evitar referência circular.
        /// </summary>
        [JsonIgnore]
        public virtual Category? Category { get; private set; }

        /// <summary>
        /// Cria uma nova transação com os dados fornecidos.
        /// Define a data de criação como o momento atual (UTC).
        /// </summary>
        /// <param name="personId">Id da pessoa que realizou a transação.</param>
        /// <param name="categoryId">Id da categoria da transação.</param>
        /// <param name="description">Descrição da transação.</param>
        /// <param name="value">Valor da transação.</param>
        /// <param name="type">Tipo da transação (Receita ou Despesa).</param>
        /// <returns>Uma nova instância de Transaction.</returns>
        public static Transaction Create(Guid personId, Guid categoryId, string description, decimal value, TransactionType type)
        {
            return new Transaction
            {
                PersonId = personId,
                CategoryId = categoryId,
                Description = description,
                Value = value,
                Type = type,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
