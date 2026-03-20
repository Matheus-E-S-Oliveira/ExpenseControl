namespace ExpenseControl.WebApi.Domain.Enums
{
    /// <summary>
    /// Define os possíveis propósitos de uma categoria no sistema de controle de gastos.
    /// Determina se a categoria é usada para despesas, receitas, ambos ou nenhum.
    /// </summary>
    public enum CategoryPurpose
    {
        /// <summary>
        /// Nenhum propósito definido.
        /// </summary>
        None,

        /// <summary>
        /// Categoria destinada a despesas.
        /// </summary>
        Expense,

        /// <summary>
        /// Categoria destinada a receitas.
        /// </summary>
        Income,

        /// <summary>
        /// Categoria que pode ser usada tanto para despesas quanto para receitas.
        /// </summary>
        Both
    }
}
