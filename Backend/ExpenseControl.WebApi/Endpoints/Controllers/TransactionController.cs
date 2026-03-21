using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações de Transação.
    /// Permite buscar, listar e criar transações.
    /// </summary>
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController(ITransactionService service) : ControllerBase
    {
        /// <summary>
        /// Busca uma transação pelo Id.
        /// </summary>
        /// <param name="id">Id da transação</param>
        /// <returns>Status HTTP e objeto ApiResponse<TransactionResponse></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await service.GetByIdAsync(id);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Retorna todas as transações cadastradas.
        /// </summary>
        /// <returns>Status HTTP e lista de transações ApiResponse<IEnumerable<TransactionResponse>></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Cria uma nova transação.
        /// </summary>
        /// <param name="request">Objeto TransactionRequest contendo PersonId, CategoryId, Description, Value e Type</param>
        /// <returns>Status HTTP e a transação criada ApiResponse<TransactionResponse></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRequest request)
        {
            var result = await service.CreateAsync(request);

            return StatusCode(result.StatusCode, result);
        }
    }
}
