using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Requests
{
    /// <summary>
    /// Representa os dados necessários para criar ou atualizar uma categoria.
    /// </summary>
    public class CategoryRequest
    {
        /// <summary>
        /// Descrição da categoria.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Finalidade da categoria (Despesa, Receita ou Ambas).
        /// </summary>
        public CategoryPurpose Purpose { get; set; }
    }
}
