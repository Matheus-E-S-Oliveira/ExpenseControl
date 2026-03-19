using ExpenseControl.WebApi.Domain.Entities;

namespace ExpenseControl.WebApi.Endpoints.Responses
{
    public class PersonResponse
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public int Age { get; init; }

        public static PersonResponse Map(Person person)
        {
            return new PersonResponse
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
            };
        }

        public static IEnumerable<PersonResponse> MapList(IEnumerable<Person> persons)
        {
            return persons.Select(Map);
        }
    }

}
