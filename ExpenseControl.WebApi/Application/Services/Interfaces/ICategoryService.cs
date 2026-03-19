using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<CategoryResponse>> GetByIdAsync(Guid id);

        Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllAsync();

        Task<ApiResponse<CategoryResponse>> CreateAsync(CategoryRequest request);
    }
}
