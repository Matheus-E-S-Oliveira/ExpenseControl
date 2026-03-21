using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de <see cref="Category"/>.
    /// Gerencia a persistência de categorias no banco de dados usando <see cref="ExpenseControlContext"/>.
    /// </summary>
    public class CategoryRepository(ExpenseControlContext context) : ICategoryRepository
    {
        /// <summary>
        /// Cria uma nova categoria e salva no banco de dados.
        /// </summary>
        /// <param name="description">Descrição da categoria.</param>
        /// <param name="purpose">Finalidade da categoria (Despesa, Receita ou Ambos).</param>
        /// <returns>A categoria criada com o Id gerado.</returns>
        public async Task<Category> CreateAsync(string description, CategoryPurpose purpose)
        {
            var category = Category.Create(
                description: description,
                purpose: purpose);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        /// <summary>
        /// Retorna todas as categorias cadastradas no banco.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        /// <summary>
        /// Retorna uma categoria pelo Id.
        /// </summary>
        /// <param name="id">Id da categoria.</param>
        /// <returns>Categoria encontrada ou null se não existir.</returns>
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await context.Categories.FindAsync(id);
        }
    }
}
