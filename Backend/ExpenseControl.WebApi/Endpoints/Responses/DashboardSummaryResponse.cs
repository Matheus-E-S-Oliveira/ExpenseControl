using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    public class DashboardSummaryResponse
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Balance { get; set; }

        public List<PersonSummaryResponse> People { get; set; } = new();

        public List<CategorySummaryResponse> Categories { get; set; } = new();

        public List<TransactionSummaryResponse> RecentTransactions { get; set; } = new();

        public class PersonSummaryResponse
        {
            public string Name { get; set; } = "";
            public int Age { get; set; }
            public decimal TotalIncome { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal Balance => TotalIncome - TotalExpenses;
        }

        public class CategorySummaryResponse
        {
            public string Description { get; set; } = "";
            public decimal TotalIncome { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal Balance => TotalIncome - TotalExpenses;
        }

        public class TransactionSummaryResponse
        {
            public string Description { get; set; } = string.Empty;
            public string PersonName { get; set; } = string.Empty;
            public TransactionType Type { get; set; }
            public decimal Value { get; set; }
        }
    }
}