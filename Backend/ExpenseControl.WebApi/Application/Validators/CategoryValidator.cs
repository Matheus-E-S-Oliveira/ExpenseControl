using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Descrição é obrigatória")
                .MaximumLength(400).WithMessage("Descrição deve ter no máximo 400 caracteres");

            RuleFor(x => x.Purpose)
                .IsInEnum().WithMessage("Finalidade inválida");
        }
    }
}
