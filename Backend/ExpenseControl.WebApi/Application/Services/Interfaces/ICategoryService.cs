using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    /// <summary>
    /// Interface do serviço de <see cref="Category"/>.
    /// Define operações de aplicação que envolvem lógica de negócio para categorias.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Obtém uma categoria pelo Id.
        /// </summary>
        /// <param name="id">Id da categoria.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{CategoryResponse}"/> com os dados da categoria ou erro.</returns>
        Task<ApiResponse<CategoryResponse>> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as categorias cadastradas.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{CategoryResponse}}"/> contendo a lista de categorias.</returns>
        Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAllAsync();

        /// <summary>
        /// Cria uma nova categoria a partir de um request de entrada.
        /// </summary>
        /// <param name="request">Objeto <see cref="CategoryRequest"/> contendo os dados da categoria a ser criada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{CategoryResponse}"/> com a categoria criada.</returns>
        Task<ApiResponse<CategoryResponse>> CreateAsync(CategoryRequest request);
    }
}
