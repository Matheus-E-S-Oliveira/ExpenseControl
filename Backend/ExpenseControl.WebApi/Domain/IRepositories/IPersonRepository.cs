using ExpenseControl.WebApi.Domain.Entities;

namespace ExpenseControl.WebApi.Domain.IRepositories
{
    /// <summary>
    /// Define as operações de persistência de dados para a entidade <see cref="Person"/>.
    /// Esta interface segue o padrão Repository, isolando o acesso ao banco de dados.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Obtém uma pessoa pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da pessoa.</param>
        /// <returns>A pessoa correspondente, ou <c>null</c> se não existir.</returns>
        Task<Person?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as pessoas cadastradas no sistema.
        /// </summary>
        /// <returns>Uma coleção de pessoas.</returns>
        Task<IEnumerable<Person>> GetAllAsync();

        /// <summary>
        /// Cria uma nova pessoa com o nome e idade fornecidos.
        /// </summary>
        /// <param name="name">Nome da pessoa.</param>
        /// <param name="age">Idade da pessoa.</param>
        /// <returns>A pessoa criada.</returns>
        Task<Person> CreateAsync(string name, int age);

        /// <summary>
        /// Atualiza os dados de uma pessoa existente.
        /// </summary>
        /// <param name="id">Identificador da pessoa a ser atualizada.</param>
        /// <param name="name">Novo nome da pessoa.</param>
        /// <param name="age">Nova idade da pessoa.</param>
        /// <returns>A pessoa atualizada, ou <c>null</c> se não existir.</returns>
        Task<Person?> UpdateAsync(Guid id, string name, int age);

        /// <summary>
        /// Exclui uma pessoa do sistema.
        /// </summary>
        /// <param name="id">Identificador da pessoa a ser excluída.</param>
        /// <returns><c>true</c> se a exclusão foi bem-sucedida, <c>false</c> caso contrário.</returns>
        Task<bool>DeleteAsync(Guid id);
    }
}
