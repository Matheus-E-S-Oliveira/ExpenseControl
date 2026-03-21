using ExpenseControl.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    /// <summary>
    /// Configuração da entidade <see cref="Person"/> para o Entity Framework Core.
    /// Define o mapeamento entre a classe e a tabela do banco de dados, incluindo tipos de colunas, chaves e restrições.
    /// </summary> 
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Configura a entidade <see cref="Person"/>.
        /// </summary>
        /// <param name="builder">Construtor do modelo usado para definir mapeamentos e restrições.</param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Define o nome da tabela
            builder.ToTable("person");

            // Define a chave primária
            builder.HasKey(x => x.Id);

            // Configura Id como auto-gerado
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Configura a coluna Name
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .HasColumnName("name")
                .HasColumnType("varchar(200)")
                .IsRequired();

            // Configura a coluna Age
            builder.Property(x => x.Age)
                .HasColumnName("age")
                .HasColumnType("int")
                .IsRequired();

            // Configura a coluna CreatedAt
            builder.Property(p => p.CreatedAt)
                 .HasColumnType("datetime(6)") 
                 .ValueGeneratedOnAdd()                   
                 .IsRequired(false);

            // Configura a coluna UpdatedAt
            builder.Property(p => p.UpdatedAt)
                 .HasColumnType("datetime(6)")
                 .ValueGeneratedOnAddOrUpdate()            
                 .IsRequired(false);
        }
    }
}
