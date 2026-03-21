using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    /// <summary>
    /// Interface do serviço de <see cref="Transaction"/>.
    /// Define operações de aplicação que envolvem lógica de negócio para transações financeiras.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Obtém uma transação pelo Id.
        /// </summary>
        /// <param name="id">Id da transação.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{TransactionResponse}"/> com os dados da transação ou erro.</returns>
        Task<ApiResponse<TransactionResponse>> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as transações cadastradas.
        /// </summary>
        /// <returns>Resposta padrão <see cref="ApiResponse{IEnumerable{TransactionResponse}}"/> contendo a lista de transações.</returns>
        Task<ApiResponse<IEnumerable<TransactionResponse>>> GetAllAsync();

        /// <summary>
        /// Cria uma nova transação a partir de um request de entrada.
        /// </summary>
        /// <param name="request">Objeto <see cref="TransactionRequest"/> contendo os dados da transação a ser criada.</param>
        /// <returns>Resposta padrão <see cref="ApiResponse{TransactionResponse}"/> com a transação criada.</returns>
        Task<ApiResponse<TransactionResponse>> CreateAsync(TransactionRequest request);
    }
}
