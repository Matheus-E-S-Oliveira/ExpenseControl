using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Requests
{
    public class CategoryRequest
    {
        public string Description { get; set; } = string.Empty;

        public CategoryPurpose Purpose { get; set; }
    }
}
