using ExpenseControl.WebApi.Domain.Entities;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    /// <summary>
    /// Representa os dados de uma pessoa para respostas da API.
    /// </summary>
    public class PersonResponse
    {
        /// <summary>
        /// Identificador único da pessoa.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Idade da pessoa.
        /// </summary>
        public int Age { get; init; }

        /// <summary>
        /// Converte uma entidade <see cref="Person"/> em <see cref="PersonResponse"/>.
        /// </summary>
        /// <param name="person">Entidade pessoa a ser mapeada.</param>
        /// <returns>Instância de <see cref="PersonResponse"/> correspondente.</returns>
        public static PersonResponse Map(Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
            };
        }

        /// <summary>
        /// Converte uma lista de entidades <see cref="Person"/> em uma lista de <see cref="PersonResponse"/>.
        /// </summary>
        /// <param name="persons">Lista de entidades pessoa.</param>
        /// <returns>Lista de <see cref="PersonResponse"/>.</returns>
        public static IEnumerable<PersonResponse> MapList(IEnumerable<Person> persons)
        {
            return persons.Select(Map);
        }
    }

}
