using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    /// <summary>
    /// Representa uma pessoa no sistema de controle de gastos residenciais.
    /// Cada pessoa pode ter várias transações associadas (receitas e despesas).
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Identificador único da pessoa.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Nome completo da pessoa.
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Idade da pessoa.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Data e hora de criação do registro da pessoa.
        /// </summary>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Data e hora da última atualização do registro da pessoa.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Coleção de transações associadas a essa pessoa.
        /// Usado para navegação no Entity Framework.
        /// Não é serializado em JSON para evitar referências circulares.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = [];

        /// <summary>
        /// Cria uma nova pessoa com nome e idade fornecidos.
        /// Define a data de criação como o momento atual.
        /// </summary>
        /// <param name="name">Nome da pessoa.</param>
        /// <param name="age">Idade da pessoa.</param>
        /// <returns>Uma nova instância de Person.</returns>
        public static Person Create(string name, int age)
        {
            return new Person
            {
                Name = name,
                Age = age,
                CreatedAt = DateTime.Now,
            };
        }

        /// <summary>
        /// Atualiza os dados da pessoa com novos valores de nome e idade.
        /// Atualiza a data de modificação como o momento atual.
        /// </summary>
        /// <param name="name">Novo nome da pessoa.</param>
        /// <param name="age">Nova idade da pessoa.</param>
        /// <returns>A própria instância de Person atualizada.</returns>
        public Person Update(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.UpdatedAt = DateTime.Now;

            return this;
        }
    }
}
