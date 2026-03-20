using ExpenseControl.WebApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController(IDashboardService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDashboardSummaryAsync()
        {
            var result = await service.GetDashboardSummaryAsync();

            return StatusCode(result.StatusCode, result);
        }
    }
}
