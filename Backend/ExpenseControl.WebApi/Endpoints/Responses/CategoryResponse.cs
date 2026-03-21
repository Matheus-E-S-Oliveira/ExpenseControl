using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    /// <summary>
    /// Representa a resposta de categoria enviada pela API.
    /// </summary>
    public class CategoryResponse
    {
        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Descrição da categoria.
        /// </summary>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Finalidade da categoria (Despesa, Receita ou Ambos).
        /// </summary>
        public CategoryPurpose Purpose { get; init; }

        /// <summary>
        /// Mapeia uma entidade <see cref="Category"/> para <see cref="CategoryResponse"/>.
        /// </summary>
        /// <param name="category">Entidade de categoria a ser mapeada.</param>
        /// <returns>Categoria convertida para CategoryResponse.</returns>
        public static CategoryResponse Map(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose
            };
        }

        /// <summary>
        /// Mapeia uma lista de entidades <see cref="Category"/> para uma lista de <see cref="CategoryResponse"/>.
        /// </summary>
        /// <param name="categories">Lista de entidades de categoria.</param>
        /// <returns>Lista de CategoryResponse.</returns>
        public static IEnumerable<CategoryResponse> MapList(IEnumerable<Category> categories)
        {
            return categories.Select(Map);
        }
    }
}
