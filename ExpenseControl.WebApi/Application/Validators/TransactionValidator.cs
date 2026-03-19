using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionRequest>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Descrição é obrigatória")
                .MaximumLength(400).WithMessage("Descrição deve ter no máximo 400 caracteres");

            RuleFor(x => x.Value)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
                .LessThanOrEqualTo(1_000_000).WithMessage("Valor não pode ser maior que 1 milhão");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Tipo inválido");

            RuleFor(x => x.PersonId)
                .NotEmpty().WithMessage("Pessoa é obrigatória");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Categoria é obrigatória");
        }
    }
}
