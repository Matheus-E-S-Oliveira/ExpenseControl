using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    /// <summary>
    /// Implementação do serviço de Dashboard.
    /// Responsável por fornecer dados agregados do sistema, como totais de receitas, despesas, saldo, pessoas, categorias e últimas transações.
    /// Interage com <see cref="IDashboardRepository"/> para consultas ao banco de dados e retorna respostas padronizadas <see cref="ApiResponse{T}"/>.
    /// </summary>
    public class DashboardService(IDashboardRepository repository) : IDashboardService
    {
        /// <summary>
        /// Obtém o resumo completo do dashboard.
        /// </summary>
        /// <returns>
        /// Resposta padrão <see cref="ApiResponse{DashboardSummaryResponse}"/> contendo:
        /// - Total de receitas e despesas
        /// - Saldo
        /// - Pessoas com seus totais de receitas e despesas
        /// - Categorias com seus totais de receitas e despesas
        /// - Últimas 10 transações cadastradas
        /// </returns>
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
