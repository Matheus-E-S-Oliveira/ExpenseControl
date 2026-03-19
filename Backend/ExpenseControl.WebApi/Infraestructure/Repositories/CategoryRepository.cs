using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    public class CategoryRepository(ExpenseControlContext context) : ICategoryRepository
    {
        public async Task<Category> CreateAsync(string description, CategoryPurpose purpose)
        {
            var category = Category.Create(
                description: description,
                purpose: purpose);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await context.Categories.FindAsync(id);
        }
    }
}
