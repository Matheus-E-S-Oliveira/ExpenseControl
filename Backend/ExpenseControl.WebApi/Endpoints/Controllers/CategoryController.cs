using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações de Categoria.
    /// Permite buscar, listar e criar categorias de transações.
    /// </summary>
    [ApiController]
    [Route("api/category")]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        /// <summary>
        /// Busca uma categoria pelo seu Id.
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Status HTTP e objeto ApiResponse<CategoryResponse></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await service.GetByIdAsync(id);

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Retorna todas as categorias cadastradas.
        /// </summary>
        /// <returns>Status HTTP e lista de categorias ApiResponse<IEnumerable<CategoryResponse>></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="request">Objeto CategoryRequest contendo Description e Purpose</param>
        /// <returns>Status HTTP e a categoria criada ApiResponse<CategoryResponse></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request)
        {
            var result = await service.CreateAsync(request);

            return StatusCode(result.StatusCode, result);
        }
    }
}
