namespace MercadinhoWeb.Application.Validators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("O nome do produto é obrigatório.");
        RuleFor(p => p.Name).Length(3, 50).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres.");
        RuleFor(p => p.Description).Length(0, 300).WithMessage("A descrição do produto deve ter no máximo 300 caracteres.");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");
        RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("O estoque do produto deve ser maior ou igual a zero.");
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("O ID da categoria do produto é obrigatório.");
    }
}
