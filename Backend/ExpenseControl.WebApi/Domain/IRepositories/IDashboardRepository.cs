using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    public interface IDashboardRepository
    {
        Task<DashboardSummaryResponse> GetDashboardSummaryAsync();
    }
}
