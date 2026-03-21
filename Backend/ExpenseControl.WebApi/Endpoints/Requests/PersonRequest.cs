namespace ExpenseControl.WebApi.Endpoints.Requests
{
    /// <summary>
    /// Representa os dados necessários para criar ou atualizar uma pessoa.
    /// </summary>
    public class PersonRequest
    {
        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Idade da pessoa.
        /// </summary>
        public int Age { get; set; }
    }
}
