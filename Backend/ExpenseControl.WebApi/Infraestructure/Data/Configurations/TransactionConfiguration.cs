using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(400)
                .HasColumnType("varchar(400)")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasDefaultValue(TransactionType.None)
                .HasColumnName("type")
                .IsRequired();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.CreatedAt)
                 .HasColumnType("datetime(6)")
                 .ValueGeneratedOnAdd()
                 .IsRequired(false);

            builder.Property(p => p.UpdatedAt)
                 .HasColumnType("datetime(6)")
                 .ValueGeneratedOnAddOrUpdate()
                 .IsRequired(false);
        }
    }
}
