using ExpenseControl.WebApi.Domain.Entities;
using ExpenseControl.WebApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(400)")
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Purpose)
                .HasColumnName("purpose")
                .HasDefaultValue(CategoryPurpose.None)
                .IsRequired();

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
