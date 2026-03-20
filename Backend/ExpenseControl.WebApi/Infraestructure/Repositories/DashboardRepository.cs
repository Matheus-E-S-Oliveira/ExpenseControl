using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Repositories
{
    public class DashboardRepository(ExpenseControlContext context) : IDashboardRepository
    {
        public async Task<DashboardSummaryResponse> GetDashboardSummaryAsync()
        {
            var totalIncome = await context.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .SumAsync(t => t.Value);

            var totalExpenses = await context.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .SumAsync(t => t.Value);

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
