using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    public class PersonValidator : AbstractValidator<PersonRequest>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(200).WithMessage("Nome deve ter no máximo 200 caracteres");

            RuleFor(x => x.Age)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Idade não pode ser negativa")
                .LessThanOrEqualTo(120).WithMessage("Idade não pode ser maior que 120 anos");
        }
    }
}
