using ExpenseControl.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Data
{
    public class ExpenseControlContext(DbContextOptions<ExpenseControlContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseControlContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
