using ExpenseControl.WebApi.Endpoints.Responses;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    /// <summary>
    /// Define as operações de leitura específicas para o dashboard do sistema.
    /// Responsável por fornecer dados agregados de receitas, despesas e pessoas.
    /// </summary>
    public interface IDashboardRepository
    {
        /// <summary>
        /// Obtém um resumo completo do dashboard contendo:
        /// 
        /// **Agregado geral:**
        /// - Total de receitas
        /// - Total de despesas
        /// - Saldo atual
        /// - Total de pessoas cadastradas
        /// 
        /// **Detalhes de pessoas:**
        /// - Lista de pessoas
        /// - Para cada pessoa: receitas, despesas e saldo
        /// 
        /// **Detalhes de categorias:**
        /// - Lista de categorias
        /// - Para cada categoria: total de transações e valores agregados por tipo
        /// 
        /// **Deatlhes das transações**
        /// - Lista das ultimas 10 transações
        /// </summary>
        /// <returns>Um <see cref="DashboardSummaryResponse"/> contendo todos os dados do dashboard.</returns>
        Task<DashboardSummaryResponse> GetDashboardSummaryAsync();
    }
}
