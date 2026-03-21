namespace ExpenseControl.WebApi.Endpoints.Responses
{
    /// <summary>
    /// Classe genérica para padronizar as respostas da API.
    /// Inclui sucesso, código de status HTTP, dados, mensagens e erros.
    /// </summary>
    /// <typeparam name="T">Tipo de dado retornado pela API.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indica se a operação foi bem-sucedida.
        /// </summary>
        public bool Success { get; init; }

        /// <summary>
        /// Código de status HTTP da resposta.
        /// </summary>
        public int StatusCode { get; init; }

        /// <summary>
        /// Dados retornados pela API, caso existam.
        /// </summary>
        public T? Data { get; init; }

        /// <summary>
        /// Mensagem de retorno, geralmente utilizada para feedback ao usuário.
        /// </summary>
        public string? Message { get; init; }

        /// <summary>
        /// Lista de erros, utilizada principalmente em casos de validação ou falha.
        /// </summary>
        public List<string>? Errors { get; init; }


        /// <summary>
        /// Cria uma resposta de sucesso com dados.
        /// </summary>
        /// <param name="statusCode">Código HTTP a ser retornado.</param>
        /// <param name="data">Dados a serem incluídos na resposta.</param>
        /// <param name="message">Mensagem de retorno.</param>
        /// <returns>ApiResponse contendo dados e mensagem.</returns>
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

        /// <summary>
        /// Cria uma resposta de erro sem dados.
        /// </summary>
        /// <param name="statusCode">Código HTTP de erro.</param>
        /// <param name="message">Mensagem explicativa do erro.</param>
        /// <returns>ApiResponse com erro e mensagem.</returns>
        public static ApiResponse<T> ErrorResponse(int statusCode, string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message
            };
        }

        /// <summary>
        /// Cria uma resposta indicando exclusão bem-sucedida.
        /// </summary>
        /// <param name="statusCode">Código HTTP de sucesso.</param>
        /// <param name="message">Mensagem de confirmação da exclusão.</param>
        /// <returns>ApiResponse com status de exclusão.</returns>
        public static ApiResponse<T> DeletedResponse(int statusCode, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Message = message
            };
        }

        /// <summary>
        /// Cria uma resposta de validação, contendo lista de erros.
        /// </summary>
        /// <param name="statusCode">Código HTTP da validação.</param>
        /// <param name="errors">Lista de mensagens de erro.</param>
        /// <returns>ApiResponse contendo os erros.</returns>
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
