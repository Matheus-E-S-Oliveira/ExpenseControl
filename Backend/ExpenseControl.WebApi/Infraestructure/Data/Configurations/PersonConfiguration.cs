using ExpenseControl.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseControl.WebApi.Infraestructure.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .HasColumnName("name")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(x => x.Age)
                .HasColumnName("age")
                .HasColumnType("int")
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
