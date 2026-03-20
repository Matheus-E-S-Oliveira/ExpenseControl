using ExpenseControl.WebApi.Application.Services;
using ExpenseControl.WebApi.Application.Services.Interfaces;
using ExpenseControl.WebApi.Application.Validators;
using ExpenseControl.WebApi.Domain.IRepositories;
using ExpenseControl.WebApi.Endpoints.Responses;
using ExpenseControl.WebApi.Infraestructure.Data;
using ExpenseControl.WebApi.Infraestructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

            builder.Services.AddDbContext<ExpenseControlContext>(option =>
                option.UseMySQL(connectionString));

            builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var response = ApiResponse<object>.ValidationResponse(
                        statusCode: StatusCodes.Status400BadRequest,
                        errors: errors);

                    return new BadRequestObjectResult(response);
                };
            });

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

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

            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpenseControl API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
