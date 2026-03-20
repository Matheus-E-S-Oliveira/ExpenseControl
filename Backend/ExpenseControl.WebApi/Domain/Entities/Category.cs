using ExpenseControl.WebApi.Domain.Enums;
using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    /// <summary>
    /// Representa uma categoria de transação no sistema de controle de gastos.
    /// As categorias são usadas para organizar e classificar transações, 
    /// podendo ter diferentes propósitos (Receita, Despesa, etc.).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Descrição ou nome da categoria (ex: "Alimentação", "Salário").
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Propósito da categoria (definido no enum CategoryPurpose).
        /// Pode indicar se é uma categoria de receita, despesa ou ambas.
        /// </summary>
        public CategoryPurpose Purpose { get; private set; }

        /// <summary>
        /// Data e hora de criação da categoria (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Data e hora da última atualização da categoria (UTC).
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Coleção de transações associadas a essa categoria.
        /// Usado para navegação no Entity Framework.
        /// Não é serializado em JSON para evitar referências circulares.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = [];

        /// <summary>
        /// Cria uma nova categoria com a descrição e propósito fornecidos.
        /// Define a data de criação como o momento atual (UTC).
        /// </summary>
        /// <param name="description">Descrição da categoria.</param>
        /// <param name="purpose">Propósito da categoria (Receita, Despesa ou Ambos).</param>
        /// <returns>Uma nova instância de Category.</returns>
        public static Category Create(string description, CategoryPurpose purpose)
        {
            return new Category
            {
                Description = description,
                Purpose = purpose,
                CreatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Atualiza a categoria com novos valores de descrição e propósito.
        /// Atualiza a data de modificação como o momento atual (UTC).
        /// </summary>
        /// <param name="description">Nova descrição da categoria.</param>
        /// <param name="purpose">Novo propósito da categoria.</param>
        /// <returns>A própria instância de Category atualizada.</returns>
        public Category Update(string description, CategoryPurpose purpose)
        {
            this.Description = description;
            this.Purpose = purpose;
            this.UpdatedAt = DateTime.UtcNow;

            return this;
        }
    }
}
