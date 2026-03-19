using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    public class PersonService(IPersonRepository repository) : IPersonService
    {
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

        public async Task<ApiResponse<IEnumerable<PersonResponse>>> GetAllAsync()
        {
            var persons = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<PersonResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: PersonResponse.MapList(persons),
                message: "Busca realizada com sucesso!");
        }

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
