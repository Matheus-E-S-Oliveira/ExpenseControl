using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    /// <summary>
    /// Configuração da entidade <see cref="Category"/> para o Entity Framework Core.
    /// Define o mapeamento entre a classe e a tabela do banco de dados, incluindo tipos de colunas, chaves e restrições.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Configura a entidade <see cref="Category"/>.
        /// </summary>
        /// <param name="builder">Construtor do modelo usado para definir mapeamentos e restrições.</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Define o nome da tabela
            builder.ToTable("category");

            // Define a chave primária
            builder.HasKey(x => x.Id);

            // Configura Id como auto-gerado
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Configura a coluna Description
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(400)")
                .HasMaxLength(400)
                .IsRequired();

            // Configura a coluna Purpose
            builder.Property(x => x.Purpose)
                .HasColumnName("purpose")
                .HasDefaultValue(CategoryPurpose.None)
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
