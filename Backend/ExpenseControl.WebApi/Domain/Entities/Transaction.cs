using ExpenseControl.WebApi.Domain.Enums;
using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }

        public string Description { get; private set; } = string.Empty;

        public decimal Value { get; private set; }

        public TransactionType Type { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid PersonId { get; private set; }

        [JsonIgnore]
        public  Person? Person { get; private set; }

        public Guid CategoryId { get; private set; }

        [JsonIgnore]
        public Category? Category { get; private set; }

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
