using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Requests
{
    public class TransactionRequest
    {
        public Guid PersonId { get; init; }

        public Guid CategoryId { get; init; }

        public string Description { get; init; } = string.Empty;

        public decimal Value { get; init; }

        public TransactionType Type { get; init; }
    }
}
