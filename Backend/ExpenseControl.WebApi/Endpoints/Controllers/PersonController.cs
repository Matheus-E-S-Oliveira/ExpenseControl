using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Endpoints.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Endpoints.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController(IPersonService service) : ControllerBase
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
        public async Task<IActionResult> Create([FromBody] PersonRequest request)
        {
            var result = await service.CreateAsync(request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PersonRequest request)
        {
            var result = await service.UpdateAsync(id, request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await service.DeleteAsync(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}
