using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ApiResponse<TransactionResponse>> GetByIdAsync(Guid id);

        Task<ApiResponse<IEnumerable<TransactionResponse>>> GetAllAsync();

        Task<ApiResponse<TransactionResponse>> CreateAsync(TransactionRequest request);
    }
}
