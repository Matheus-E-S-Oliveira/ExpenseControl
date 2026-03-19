using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Repositories;

namespace ExpenseControl.WebApi.Application.Services
{
    public class TransactionService(TransactionRepository repository, PersonRepository personRepository, CategoryRepository categoryRepository) : ITransactionService
    {
        public async Task<ApiResponse<TransactionResponse>> CreateAsync(TransactionRequest request)
        {
            var person = await personRepository.GetByIdAsync(request.PersonId);

            if (person is null)
                return ApiResponse<TransactionResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Pessoa não encontrada!");

            var category = await categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
                return ApiResponse<TransactionResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Categoria não encontrada!");

            if (!ValidateAge(person.Age, request.Type))
                return ApiResponse<TransactionResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status400BadRequest,
                    message: "Menor de idade só pode possuir despesas");

            if (!ValidateCategoryCompatibility(category.Purpose, request.Type))
                return ApiResponse<TransactionResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status400BadRequest,
                    message: "Categoria incompatível com o tipo da transação!");

            var transaction = await repository.CreateAsync(
                personId: request.PersonId,
                categoryId: request.CategoryId,
                value: request.Value,
                description: request.Description,
                type: request.Type);

            return ApiResponse<TransactionResponse>.SuccessResponse(
                statusCode: StatusCodes.Status201Created,
                data: TransactionResponse.Map(transaction),
                message: "Transação cadastrada com sucesso!");
        }

        public async Task<ApiResponse<IEnumerable<TransactionResponse>>> GetAllAsync()
        {
            var transactions = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<TransactionResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: TransactionResponse.MapList(transactions),
                message: "Busca realizada com sucesso!");
        }

        public async Task<ApiResponse<TransactionResponse>> GetByIdAsync(Guid id)
        {
            var transaction = await repository.GetByIdAsync(id);

            if (transaction is null)
                return ApiResponse<TransactionResponse>.ErrorResponse(
                    statusCode: StatusCodes.Status404NotFound,
                    message: "Transação não encontrada");

            return ApiResponse<TransactionResponse>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: TransactionResponse.Map(transaction),
                message: "Transação encontrada com sucesso!");
        }

        private static bool ValidateAge(int age, TransactionType type)
        {
            return !(age < 18 && type == TransactionType.Income);
        }

        private static bool ValidateCategoryCompatibility(CategoryPurpose purpose, TransactionType type)
        {
            return purpose == CategoryPurpose.Both ||
               (type == TransactionType.Expense && purpose == CategoryPurpose.Expense) ||
               (type == TransactionType.Income && purpose == CategoryPurpose.Income);
        }
    }
}
