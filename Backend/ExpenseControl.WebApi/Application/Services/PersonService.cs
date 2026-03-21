using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    /// <summary>
    /// Implementação do serviço de <see cref="Person"/>.
    /// Responsável por aplicar regras de negócio e gerenciar pessoas no sistema.
    /// Interage com <see cref="IPersonRepository"/> para persistência e retorna respostas padronizadas <see cref="ApiResponse{T}"/>.
    /// </summary>
    public class PersonService(IPersonRepository repository) : IPersonService
    {
        /// <summary>
        /// Cria uma nova pessoa no sistema.
        /// </summary>
        /// <param name="request">Objeto <see cref="PersonRequest"/> contendo os dados da pessoa.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com a pessoa criada.</returns>
        public async Task<ApiResponse<PersonResponse>> CreateAsync(PersonRequest request)
        {
            var person = await repository.CreateAsync(
                name: request.Name,
                age: request.Age);

            return ApiResponse<PersonResponse>.SuccessResponse(
                statusCode: StatusCodes.Status201Created,
                data: PersonResponse.Map(person),
                message: "Pessoa cadastrada com sucesso!");
        }

        /// <summary>
        /// Remove uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa a ser removida.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> indicando sucesso ou falha.</returns>
        public async Task<ApiResponse<PersonResponse>> DeleteAsync(Guid id)
        {
            var deleted = await repository.DeleteAsync(id);

            if (deleted is false) 
                return ApiResponse<PersonResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound, 
                    message: "Pessoa não foi encontrada");

            return ApiResponse<PersonResponse>.DeletedResponse(
                statusCode: StatusCodes.Status200OK,
                message: "Pessoa removida com sucesso!");
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas no sistema.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{PersonResponse}}"/> contendo a lista de pessoas.</returns>
        public async Task<ApiResponse<IEnumerable<PersonResponse>>> GetAllAsync()
        {
            var persons = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<PersonResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: PersonResponse.MapList(persons),
                message: "Busca realizada com sucesso!");
        }

        /// <summary>
        /// Obtém uma pessoa pelo Id.
        /// </summary>
        /// <param name="id">Id da pessoa a ser buscada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com a pessoa encontrada ou erro 404 se não existir.</returns>
        public async Task<ApiResponse<PersonResponse>> GetByIdAsync(Guid id)
        {
            var person = await repository.GetByIdAsync(id);

            if (person is null)
                return ApiResponse<PersonResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Pessoa não encontrada");

            return ApiResponse<PersonResponse>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: PersonResponse.Map(person),
                message: "Pessoa encontrada com sucesso!");
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// </summary>
        /// <param name="id">Id da pessoa a ser atualizada.</param>
        /// <param name="request">Objeto <see cref="PersonRequest"/> contendo os novos dados.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{PersonResponse}"/> com a pessoa atualizada ou erro 404 se não existir.</returns>
        public async Task<ApiResponse<PersonResponse>> UpdateAsync(Guid id, PersonRequest request)
        {
            var person = await repository.UpdateAsync(
                id: id,
                name: request.Name,
                age: request.Age);

            if (person is null)
                return ApiResponse<PersonResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Pessoa não foi encontrada");

            return ApiResponse<PersonResponse>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: PersonResponse.Map(person),
                message: "Dados da pessoa atualizados com sucesso!");
        }
    }
}
