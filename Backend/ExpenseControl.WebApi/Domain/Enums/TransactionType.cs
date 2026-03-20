namespace ExpenseControl.WebApi.Domain.Enums
{
    /// <summary>
    /// Define os tipos de transação no sistema de controle de gastos.
    /// Determina se a transação é uma despesa, uma receita ou não definida.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Tipo de transação não definido.
        /// </summary>
        None,

        /// <summary>
        /// Transação de despesa.
        /// </summary>
        Expense,

        /// <summary>
        /// Transação de receita.
        /// </summary>
        Income
    }
}
