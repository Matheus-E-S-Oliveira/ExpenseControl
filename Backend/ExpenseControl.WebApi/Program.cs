using ExpenseControl.WebApi.Application.Extensions;
using ExpenseControl.WebApi.Application.Validators;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi
{
    /// <summary>
    /// Ponto de entrada da aplicação ExpenseControl.
    /// Configura o WebApplication, registrando serviços, repositórios, validação, CORS e Swagger.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Cria o builder da aplicação
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona controllers e suporte a OpenAPI/Swagger
            builder.Services.AddControllers();

            // Configuração mínima do OpenAPI
            builder.Services.AddOpenApi();

            // Para mapear endpoints automaticamente
            builder.Services.AddEndpointsApiExplorer();

            // Gera documentação Swagger
            builder.Services.AddSwaggerGen();

            // Configura conexão com o banco de dados via MySQL
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

            builder.Services.AddDbContext<ExpenseControlContext>(option =>
                option.UseMySQL(connectionString));

            // Registra validators do FluentValidation para cada entidade
            builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();

            // Registra services e repositórios usando extensões criadas
            builder.Services.AddApplicationServices();
            builder.Services.AddRepositories();

            // Configura respostas padronizadas para validações de ModelState
            builder.Services.ConfigureCustomValidation();

            // Configuração do CORS para permitir requisições do frontend local
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            // Build do aplicativo
            var app = builder.Build();

            // Aplica política de CORS
            app.UseCors(MyAllowSpecificOrigins);

            // Configurações específicas para ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                // Mapeia endpoints do OpenAPI
                app.MapOpenApi();

                // Habilita Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpenseControl API V1");
                    c.RoutePrefix = string.Empty; // Swagger na raiz
                });
            }

            // Força redirecionamento para HTTPS
            app.UseHttpsRedirection();

            // Configura autorização (não há autenticação configurada ainda)
            app.UseAuthorization();

            // Mapeia controllers para os endpoints da API
            app.MapControllers();

            // Executa a aplicação
            app.Run();
        }
    }
}
