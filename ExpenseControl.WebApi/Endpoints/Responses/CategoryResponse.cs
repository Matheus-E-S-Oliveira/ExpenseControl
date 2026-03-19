using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; init; }

        public string Description { get; init; } = string.Empty;

        public CategoryPurpose Purpose { get; init; }

        public static CategoryResponse Map(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose
            };
        }

        public static IEnumerable<CategoryResponse> MapList(IEnumerable<Category> categories)
        {
            return categories.Select(Map);
        }
    }
}
