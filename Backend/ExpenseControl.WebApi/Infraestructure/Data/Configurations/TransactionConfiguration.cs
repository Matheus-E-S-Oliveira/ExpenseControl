using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    /// <summary>
    /// Configuração da entidade <see cref="Transaction"/> para o Entity Framework Core.
    /// Define o mapeamento entre a classe e a tabela do banco de dados, incluindo tipos de colunas, chaves primárias e estrangeiras.
    /// </summary>
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        /// <summary>
        /// Configura a entidade <see cref="Transaction"/>.
        /// </summary>
        /// <param name="builder">Construtor do modelo usado para definir mapeamentos e restrições.</param>

        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // Define o nome da tabela
            builder.ToTable("transaction");

            // Define a chave primária
            builder.HasKey(x => x.Id);

            // Configura Id como auto-gerado
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Configura a coluna Description
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired();

            // Configura a coluna Type
            builder.Property(x => x.Type)
                .HasDefaultValue(TransactionType.None)
                .HasColumnName("type")
                .IsRequired();

            // Configura o relacionamento com Person (1:N)
            builder.HasOne(x => x.Person)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configura o relacionamento com Category (1:N)
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

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
