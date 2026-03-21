using ExpenseControl.WebApi.Endpoints.Requests;
using FluentValidation;

namespace ExpenseControl.WebApi.Application.Validators
{
    /// <summary>
    /// Validador de CategoryRequest usando FluentValidation.
    /// Garantir que os dados enviados para criar ou atualizar uma categoria sejam válidos.
    /// </summary>
    public class CategoryValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryValidator()
        {
            // Valida a propriedade Description
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop) // Para execução de validação em caso de falha, impede regras posteriores
                .NotEmpty().WithMessage("Descrição é obrigatória") // Não pode ser vazio
                .MaximumLength(400).WithMessage("Descrição deve ter no máximo 400 caracteres"); // Limite de 400 caracteres

            // Valida a propriedade Purpose (enum)
            RuleFor(x => x.Purpose)
                .IsInEnum().WithMessage("Finalidade inválida"); // Deve ser um valor válido do enum CategoryPurpose
        }
    }
}
