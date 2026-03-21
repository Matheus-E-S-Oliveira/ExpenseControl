using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    /// <summary>
    /// Validador de PersonRequest usando FluentValidation.
    /// Garante que os dados enviados para criar ou atualizar uma pessoa sejam válidos.
    /// </summary>
    public class PersonValidator : AbstractValidator<PersonRequest>
    {
        public PersonValidator()
        {
            // Valida a propriedade Name
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop) // Para execução de validação em caso de falha, impede regras posteriores
                .NotEmpty().WithMessage("Nome é obrigatório") // Não pode ser vazio
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres"); // Limite de 200 caracteres

            // Valida a propriedade Age
            RuleFor(x => x.Age)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Idade não pode ser negativa") // Não pode ser menor que 0
                .LessThanOrEqualTo(120).WithMessage("Idade não pode ser maior que 120 anos");// Limite máximo razoável
        } 
    }
}
