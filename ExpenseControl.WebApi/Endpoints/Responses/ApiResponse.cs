namespace ExpenseControl.WebApi.Endpoints.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }

        public int StatusCode { get; init; }

        public T? Data { get; init; }

        public string? Message { get; init; }

        public List<string>? Errors { get; init; }


        public static ApiResponse<T> SuccessResponse(int statusCode, T data, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Data = data,
                Message = message
            };
        }

        public static ApiResponse<T> ErrorResponse(int statusCode, string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> DeletedResponse(int statusCode, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> ValidationResponse(int statusCode, List<string> errors)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Errors = errors
            };
        } 
    }
}
