using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    /// <summary>
    /// Interface do serviço de <see cref="Person"/>.
    /// Define operações de aplicação que envolvem lógica de negócio para pessoas cadastradas.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Obtém uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com os dados da pessoa ou erro.</returns>
        Task<ApiResponse<PersonResponse>> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as pessoas cadastradas.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{PersonResponse}}"/> contendo a lista de pessoas.</returns>
        Task<ApiResponse<IEnumerable<PersonResponse>>> GetAllAsync();

        /// <summary>
        /// Cria uma nova pessoa a partir de um request de entrada.
        /// </summary>
        /// <param name="request">Objeto <see cref="PersonRequest"/> contendo os dados da pessoa a ser criada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com a pessoa criada.</returns>
        Task<ApiResponse<PersonResponse>> CreateAsync(PersonRequest request);

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// </summary>
        /// <param name="id">Id da pessoa a ser atualizada.</param>
        /// <param name="request">Objeto <see cref="PersonRequest"/> contendo os novos dados.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com a pessoa atualizada ou erro.</returns>
        Task<ApiResponse<PersonResponse>> UpdateAsync(Guid id, PersonRequest request);

        /// <summary>
        /// Remove uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa a ser removida.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> indicando sucesso ou falha.</returns>
        Task<ApiResponse<PersonResponse>> DeleteAsync(Guid id);
    }
}
