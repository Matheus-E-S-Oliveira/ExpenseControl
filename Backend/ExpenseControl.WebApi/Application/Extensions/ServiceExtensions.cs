using ExpenseControl.WebApi.Application.Services;
using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.WebApi.Application.Extensions
{
    /// <summary>
    /// Extensões para registrar serviços, repositórios e configuração de validação customizada
    /// na injeção de dependência do ASP.NET Core.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registra todos os serviços de aplicação (services) no container de injeção de dependência.
        /// Serviços são responsáveis por encapsular a lógica de negócio.
        /// </summary>
        /// <param name="services">IServiceCollection da aplicação.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IDashboardService, DashboardService>();
        }

        /// <summary>
        /// Registra todos os repositórios no container de injeção de dependência.
        /// Repositórios são responsáveis pelo acesso aos dados e abstração do banco.
        /// </summary>
        /// <param name="services">IServiceCollection da aplicação.</param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
        }

        /// <summary>
        /// Configura a validação customizada do ASP.NET Core para retornar respostas padronizadas
        /// usando ApiResponse quando a ModelState estiver inválida.
        /// </summary>
        /// <param name="services">IServiceCollection da aplicação.</param>
        public static void ConfigureCustomValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var response = ApiResponse<object>.ValidationResponse(
                        statusCode: StatusCodes.Status400BadRequest,
                        errors: errors
                    );

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
