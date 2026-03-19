using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Endpoints.Requests;
using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ApiResponse<PersonResponse>> GetByIdAsync(Guid id);

        Task<ApiResponse<IEnumerable<PersonResponse>>> GetAllAsync();

        Task<ApiResponse<PersonResponse>> CreateAsync(PersonRequest request);

        Task<ApiResponse<PersonResponse>> UpdateAsync(Guid id, PersonRequest request);

        Task<ApiResponse<PersonResponse>> DeleteAsync(Guid id);
    }
}
