using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações de Pessoa.
    /// Permite buscar, listar, criar, atualizar e deletar pessoas.
    /// </summary>
    [ApiController]
    [Route("api/person")]
    public class PersonController(IPersonService service) : ControllerBase
    {
        /// <summary>
        /// Busca uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Status HTTP e objeto ApiResponse<PersonResponse></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await service.GetByIdAsync(id);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas.
        /// </summary>
        /// <returns>Status HTTP e lista de pessoas ApiResponse<IEnumerable<PersonResponse>></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Cria uma nova pessoa.
        /// </summary>
        /// <param name="request">Objeto PersonRequest com Name e Age</param>
        /// <returns>Status HTTP e a pessoa criada ApiResponse<PersonResponse></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonRequest request)
        {
            var result = await service.CreateAsync(request);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <param name="request">Objeto PersonRequest com Name e Age</param>
        /// <returns>Status HTTP e a pessoa atualizada ApiResponse<PersonResponse></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PersonRequest request)
        {
            var result = await service.UpdateAsync(id, request);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Remove uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Status HTTP e mensagem de remoção ApiResponse<PersonResponse></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await service.DeleteAsync(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}
