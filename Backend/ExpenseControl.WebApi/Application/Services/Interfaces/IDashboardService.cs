using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    /// <summary>
    /// Interface do serviço de Dashboard.
    /// Define operações de aplicação relacionadas à obtenção de dados agregados para relatórios e visualização do sistema.
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Obtém o resumo completo do dashboard.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{DashboardSummaryResponse}"/> contendo totais de receitas, despesas, saldo, pessoas, categorias e últimas transações.</returns>
        Task<ApiResponse<DashboardSummaryResponse>> GetDashboardSummaryAsync();
    }
}
