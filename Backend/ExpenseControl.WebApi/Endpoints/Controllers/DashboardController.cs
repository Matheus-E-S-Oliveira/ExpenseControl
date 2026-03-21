using ExpenseControl.WebApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    /// <summary>
    /// Controller responsável por fornecer o resumo do dashboard do sistema.
    /// Inclui totais de receitas, despesas, saldo, pessoas, categorias e últimas transações.
    /// </summary>
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController(IDashboardService service) : ControllerBase
    {
        /// <summary>
        /// Retorna o resumo completo do dashboard.
        /// </summary>
        /// <returns>Status HTTP e objeto ApiResponse contendo DashboardSummaryResponse</returns>
        [HttpGet]
        public async Task<IActionResult> GetDashboardSummaryAsync()
        {
            var result = await service.GetDashboardSummaryAsync();

            return StatusCode(result.StatusCode, result);
        }
    }
}
