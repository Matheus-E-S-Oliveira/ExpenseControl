using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    public class CategoryService(ICategoryRepository repository) : ICategoryService
    {
        public async Task<ApiResponse<CategoryResponse>> CreateAsync(CategoryRequest request)
        {
            var category = await repository.CreateAsync(
                description: request.Description,
                purpose: request.Purpose);

            return ApiResponse<CategoryResponse>.SuccessResponse(
                statusCode: StatusCodes.Status201Created,
                data: CategoryResponse.Map(category),
                message: "Categoria cadastrada com sucesso!");
        }

        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllAsync()
        {
            var category = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<CategoryResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: CategoryResponse.MapList(category),
                message: "Busca realizada com sucesso!");
        }

        public async Task<ApiResponse<CategoryResponse>> GetByIdAsync(Guid id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category is null)
                return ApiResponse<CategoryResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Categoria não encontrada");

            return ApiResponse<CategoryResponse>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: CategoryResponse.Map(category),
                message: "Categoria encontrada com sucesso!");
        }
    }
}
