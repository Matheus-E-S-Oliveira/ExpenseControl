using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await service.GetByIdAsync(id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request)
        {
            var result = await service.CreateAsync(request);

            return StatusCode(result.StatusCode, result);
        }
    }
}
