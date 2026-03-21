using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de Dashboard.
    /// Fornece dados agregados para relatórios e visualização resumida do sistema.
    /// </summary>
    public class DashboardRepository(ExpenseControlContext context) : IDashboardRepository
    {
        /// <summary>
        /// Retorna um resumo completo do dashboard, incluindo receitas, despesas, saldo,
        /// lista de pessoas com seus totais e categorias com totais de transações.
        /// </summary>
        /// <returns><see cref="DashboardSummaryResponse"/> com todos os dados do dashboard.</returns>
        public async Task<DashboardSummaryResponse> GetDashboardSummaryAsync()
        {
            // Calcula total de receitas no sistema
            var totalIncome = await context.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .SumAsync(t => t.Value);

            // Calcula total de despesas no sistema
            var totalExpenses = await context.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .SumAsync(t => t.Value);

            // Lista pessoas com seus totais de receitas e despesas
            var people = await context.Persons
                .Select(p => new DashboardSummaryResponse.PersonSummaryResponse
                {
                    Name = p.Name,
                    Age = p.Age,
                    TotalIncome = context.Transactions
                        .Where(t => t.PersonId == p.Id && t.Type == TransactionType.Income)
                        .Sum(t => t.Value),
                    TotalExpenses = context.Transactions
                        .Where(t => t.PersonId == p.Id && t.Type == TransactionType.Expense)
                        .Sum(t => t.Value)
                })
                .OrderBy(p =>  p.Name)
                .ToListAsync();

            // Lista categorias com seus totais de receitas e despesas
            var categories = await context.Categories
                .Select(c => new DashboardSummaryResponse.CategorySummaryResponse
                {
                    Description = c.Description,
                    TotalIncome = context.Transactions
                        .Where(t => t.CategoryId == c.Id && t.Type == TransactionType.Income)
                        .Sum(t => t.Value),
                    TotalExpenses = context.Transactions
                        .Where(t => t.CategoryId == c.Id && t.Type == TransactionType.Expense)
                        .Sum(t => t.Value)
                })
                .ToListAsync();

            // Lista últimas 10 transações registradas
            var recentTransactions = await context.Transactions
                .Include(t => t.Person)
                .OrderByDescending(t => t.CreatedAt)
                .Take(10)
                .Select(t => new DashboardSummaryResponse.TransactionSummaryResponse
                {
                    Description = t.Description,
                    PersonName = t.Person != null ? t.Person.Name : "Pessoa removida",
                    Type = t.Type,
                    Value = t.Value
                })
                .ToListAsync();

            // Retorna objeto agregador com todos os dados
            return new DashboardSummaryResponse
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                Balance = totalIncome - totalExpenses,
                People = people,
                Categories = categories,
                RecentTransactions = recentTransactions
            };
        }
    }
}
