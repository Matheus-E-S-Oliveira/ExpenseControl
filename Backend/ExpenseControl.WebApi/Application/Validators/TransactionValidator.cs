using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    /// <summary>
    /// Validador de TransactionRequest usando FluentValidation.
    /// Garante que os dados enviados para criar uma transação sejam válidos.
    /// </summary>
    public class TransactionValidator : AbstractValidator<TransactionRequest>
    {
        public TransactionValidator()
        {
            // Valida a propriedade Description
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Descrição é obrigatória") // Não pode estar vazia
                .MaximumLength(400).WithMessage("Descrição deve ter no máximo 400 caracteres"); // Limite de 400 caracteres

            // Valida o valor da transação
            RuleFor(x => x.Value)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero") // Valor positivo
                .LessThanOrEqualTo(1_000_000).WithMessage("Valor não pode ser maior que 1 milhão"); // Limite superior

            // Valida o tipo da transação (Expense ou Income)
            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Tipo inválido"); // Deve ser um valor válido do enum TransactionType

            // Valida o ID da pessoa
            RuleFor(x => x.PersonId)
                .NotEmpty().WithMessage("Pessoa é obrigatória"); // Obrigatório

            // Valida o ID da categoria
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Categoria é obrigatória"); // Obrigatório
        }
    }
}
