using ExpenseControl.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi.Infraestructure.Data
{
    /// <summary>
    /// Contexto do Entity Framework Core para o sistema ExpenseControl.
    /// Representa a sessão com o banco de dados e fornece acesso às tabelas do sistema.
    /// </summary>
    public class ExpenseControlContext(DbContextOptions<ExpenseControlContext> options) : DbContext(options)
    {
        /// <summary>
        /// DbSet para gerenciar categorias de transações.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// DbSet para gerenciar transações financeiras.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// DbSet para gerenciar transações financeiras.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Configura o modelo do banco de dados.
        /// Aplica todas as configurações de entidade definidas na mesma assembly.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo usado pelo EF Core.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações de entidade (IEntityTypeConfiguration) registradas na assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseControlContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
