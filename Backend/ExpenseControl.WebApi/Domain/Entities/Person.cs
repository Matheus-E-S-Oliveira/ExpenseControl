using System.Text.Json.Serialization;

namespace ExpenseControl.WebApi.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int Age { get; private set; }

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = [];

        public static Person Create(string name, int age)
        {
            return new Person
            {
                Name = name,
                Age = age
            };
        }

        public Person Update(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            return this;
        }
    }
}
