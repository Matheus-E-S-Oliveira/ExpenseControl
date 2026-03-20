using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    /// <summary>
    /// Define as operações de persistência de dados para a entidade <see cref="Category"/>.
    /// Esta interface segue o padrão Repository, isolando o acesso ao banco de dados.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Obtém uma categoria pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da categoria.</param>
        /// <returns>A categoria correspondente, ou <c>null</c> se não existir.</returns>
        Task<Category?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as categorias existentes no sistema.
        /// </summary>
        /// <returns>Uma coleção de todas as categorias.</returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Cria uma nova categoria com a descrição e propósito fornecidos.
        /// </summary>
        /// <param name="description">Descrição da nova categoria.</param>
        /// <param name="purpose">Propósito da categoria (<see cref="CategoryPurpose"/>).</param>
        /// <returns>A categoria criada.</returns>
        Task<Category> CreateAsync(string description, CategoryPurpose purpose);

    }
}
