using ExpenseControl.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Data
{
    public class ExpenseControlContext(DbContextOptions<ExpenseControlContext> options) : DbContext(options)
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Person> Persons { get; set; }

        DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseControlContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
