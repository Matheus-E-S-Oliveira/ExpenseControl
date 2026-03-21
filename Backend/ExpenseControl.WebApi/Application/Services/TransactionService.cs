using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.Enums;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services
{
    /// <summary>
    /// Implementação do serviço de <see cref="Transaction"/>.
    /// Responsável por aplicar regras de negócio e gerenciar transações financeiras no sistema.
    /// Interage com <see cref="ITransactionRepository"/>, <see cref="IPersonRepository"/> e <see cref="ICategoryRepository"/>.
    /// Retorna respostas padronizadas <see cref="ApiResponse{T}"/>.
    /// </summary>
    public class TransactionService(
        ITransactionRepository repository, 
        IPersonRepository personRepository, 
        ICategoryRepository categoryRepository) : ITransactionService
    {
        /// <summary>
        /// Cria uma nova transação no sistema.
        /// </summary>
        /// <param name="request">Objeto <see cref="TransactionRequest"/> contendo dados da transação.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{TransactionResponse}"/> com a transação criada ou erro de validação.</returns>
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

        /// <summary>
        /// Retorna todas as transações cadastradas.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{TransactionResponse}}"/> contendo a lista de transações.</returns>
        public async Task<ApiResponse<IEnumerable<TransactionResponse>>> GetAllAsync()
        {
            var transactions = await repository.GetAllAsync();

            return ApiResponse<IEnumerable<TransactionResponse>>.SuccessResponse(
                statusCode: StatusCodes.Status200OK,
                data: TransactionResponse.MapList(transactions),
                message: "Busca realizada com sucesso!");
        }

        /// <summary>
        /// Obtém uma transação pelo Id.
        /// </summary>
        /// <param name="id">Id da transação a ser buscada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{TransactionResponse}"/> com a transação encontrada ou erro 404 se não existir.</returns>
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

        /// <summary>
        /// Valida se a idade da pessoa permite determinado tipo de transação.
        /// Menores de 18 anos não podem ter receitas (income).
        /// </summary>
        /// <param name="age">Idade da pessoa.</param>
        /// <param name="type">Tipo da transação.</param>
        /// <returns>True se válido, False caso contrário.</returns>
        private static bool ValidateAge(int age, TransactionType type)
        {
            return !(age < 18 && type == TransactionType.Income);
        }

        /// <summary>
        /// Valida a compatibilidade da categoria com o tipo da transação.
        /// </summary>
        /// <param name="purpose">Propósito da categoria.</param>
        /// <param name="type">Tipo da transação.</param>
        /// <returns>True se compatível, False caso contrário.</returns>
        private static bool ValidateCategoryCompatibility(CategoryPurpose purpose, TransactionType type)
        {
            return purpose == CategoryPurpose.Both ||
               (type == TransactionType.Expense && purpose == CategoryPurpose.Expense) ||
               (type == TransactionType.Income && purpose == CategoryPurpose.Income);
        }
    }
}
