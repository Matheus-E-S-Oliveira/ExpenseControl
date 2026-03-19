using ExpenseControl.WebApi.Domain.Enums;
using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }

        public string Description { get; private set; } = string.Empty;

        public CategoryPurpose Purpose { get; private set; }

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = [];

        public static Category Create(string description, CategoryPurpose purpose)
        {
            return new Category
            {
                Description = description,
                Purpose = purpose
            };
        }

        public Category Update(string description, CategoryPurpose purpose)
        {
            this.Description = description;
            this.Purpose = purpose;

            return this;
        }
    }
}
