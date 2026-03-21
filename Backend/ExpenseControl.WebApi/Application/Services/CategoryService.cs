using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    /// <summary>
    /// Implementação do serviço de <see cref="Category"/>.
    /// Responsável por aplicar regras de negócio e gerenciar categorias.
    /// Interage com o <see cref="ICategoryRepository"/> para persistência e retorna respostas padronizadas <see cref="ApiResponse{T}"/>.
    /// </summary>
    public class CategoryService(ICategoryRepository repository) : ICategoryService
    {
        /// <summary>
        /// Cria uma nova categoria no sistema.
        /// </summary>
        /// <param name="request">Request contendo os dados da categoria.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{CategoryResponse}"/> com a categoria criada ou erro.</returns>
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

        /// <summary>
        /// Retorna todas as categorias cadastradas no sistema.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{CategoryResponse}}"/> contendo a lista de categorias.</returns>
        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllAsync()
        {
            var category = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<CategoryResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: CategoryResponse.MapList(category),
                message: "Busca realizada com sucesso!");
        }

        /// <summary>
        /// Obtém uma categoria pelo Id.
        /// </summary>
        /// <param name="id">Id da categoria a ser buscada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{CategoryResponse}"/> com a categoria encontrada ou erro 404 se não existir.</returns>
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
