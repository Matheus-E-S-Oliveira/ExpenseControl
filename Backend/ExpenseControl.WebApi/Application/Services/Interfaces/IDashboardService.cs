using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<ApiResponse<DashboardSummaryResponse>> GetDashboardSummaryAsync();
    }
}
