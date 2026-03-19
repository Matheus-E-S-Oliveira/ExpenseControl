using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    public class TransactionResponse
    {
        public Guid Id { get; init; }

        public string Description { get; init; } = string.Empty;

        public decimal Value { get; init; }

        public TransactionType Type { get; init; }

        public PersonResponse? Person { get; init; }

        public CategoryResponse? Category { get; init; }

        public static TransactionResponse Map(Transaction transaction)
        {
            return new TransactionResponse
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Value = transaction.Value,
                Type = transaction.Type,
                Person = transaction.Person is not null ? PersonResponse.Map(transaction.Person) : null,
                Category = transaction.Category is not null ? CategoryResponse.Map(transaction.Category) : null,
            };
        }

        public static IEnumerable<TransactionResponse> MapList(IEnumerable<Transaction> transactions)
        {
            return transactions.Select(Map);
        }
    }
}
