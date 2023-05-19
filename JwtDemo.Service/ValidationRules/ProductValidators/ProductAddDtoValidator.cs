using FluentValidation;
using JwtDemo.DTOs.ProductDtos;

namespace JwtDemo.Service.ValidationRules.ProductValidators;

public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
{
    public ProductAddDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ürün adı boş olamaz")
            .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır")
            .MaximumLength(128).WithMessage("Ürün adı en fazla 128 karakter olmalıdır");

        RuleFor(x => x.Description)
            .MinimumLength(3).WithMessage("Ürün açıklama en az 3 karakter olmalıdır")
            .MaximumLength(512).WithMessage("Ürün açıklama en fazla 512 karakter olmalıdır");
    }
}
