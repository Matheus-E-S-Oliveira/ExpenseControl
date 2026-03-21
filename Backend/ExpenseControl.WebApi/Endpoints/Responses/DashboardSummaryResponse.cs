using ExpenseControl.WebApi.Domain.Enums;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    /// <summary>
    /// Representa o resumo do dashboard, incluindo totais gerais, pessoas, categorias e transações recentes.
    /// </summary>
    public class DashboardSummaryResponse
    {
        /// <summary>
        /// Total de receitas registradas.
        /// </summary>
        public decimal TotalIncome { get; set; }

        /// <summary>
        /// Total de despesas registradas.
        /// </summary>
        public decimal TotalExpenses { get; set; }

        /// <summary>
        /// Saldo geral, calculado como TotalIncome - TotalExpenses.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Lista de resumo financeiro por pessoa.
        /// </summary>
        public List<PersonSummaryResponse> People { get; set; } = new();

        /// <summary>
        /// Lista de resumo financeiro por categoria.
        /// </summary>
        public List<CategorySummaryResponse> Categories { get; set; } = new();

        /// <summary>
        /// Lista das últimas transações registradas.
        /// </summary>
        public List<TransactionSummaryResponse> RecentTransactions { get; set; } = new();

        /// <summary>
        /// Representa o resumo financeiro de uma pessoa.
        /// </summary>
        public class PersonSummaryResponse
        {
            /// <summary>
            /// Nome da pessoa.
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Idade da pessoa.
            /// </summary>
            public int Age { get; set; }

            /// <summary>
            /// Total de receitas da pessoa.
            /// </summary>
            public decimal TotalIncome { get; set; }

            /// <summary>
            /// Total de despesas da pessoa.
            /// </summary>
            public decimal TotalExpenses { get; set; }

            /// <summary>
            /// Saldo da pessoa, calculado como TotalIncome - TotalExpenses.
            /// </summary>
            public decimal Balance => TotalIncome - TotalExpenses;
        }

        /// <summary>
        /// Representa o resumo financeiro de uma categoria.
        /// </summary>
        public class CategorySummaryResponse
        {
            /// <summary>
            /// Descrição da categoria.
            /// </summary>
            public string Description { get; set; } = string.Empty;

            /// <summary>
            /// Total de receitas associadas à categoria.
            /// </summary>
            public decimal TotalIncome { get; set; }

            /// <summary>
            /// Total de despesas associadas à categoria.
            /// </summary>
            public decimal TotalExpenses { get; set; }

            /// <summary>
            /// Saldo da categoria, calculado como TotalIncome - TotalExpenses.
            /// </summary>
            public decimal Balance => TotalIncome - TotalExpenses;
        }

        /// <summary>
        /// Representa o resumo de uma transação individual.
        /// </summary>
        public class TransactionSummaryResponse
        {
            /// <summary>
            /// Descrição da transação.
            /// </summary>
            public string Description { get; set; } = string.Empty;

            /// <summary>
            /// Nome da pessoa associada à transação.
            /// </summary>
            public string PersonName { get; set; } = string.Empty;

            /// <summary>
            /// Tipo da transação (Receita ou Despesa).
            /// </summary>
            public TransactionType Type { get; set; }

            /// <summary>
            /// Valor da transação.
            /// </summary>
            public decimal Value { get; set; }
        }
    }
}