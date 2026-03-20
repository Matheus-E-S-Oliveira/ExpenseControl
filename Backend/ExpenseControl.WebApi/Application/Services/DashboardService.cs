using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    public class DashboardService(IDashboardRepository repository) : IDashboardService
    {
        public async Task<ApiResponse<DashboardSummaryResponse>> GetDashboardSummaryAsync()
        {
            var result = await repository.GetDashboardSummaryAsync();
            return ApiResponse<DashboardSummaryResponse>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: result,
                message: "Busca realizada com sucesso");
        }
    }
}
