using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductName).NotEmpty();
        RuleFor(c => c.SupplierId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.QuantityPerUnit).NotEmpty();
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.UnitsInStock).NotEmpty();
        RuleFor(c => c.UnitsOnOrder).NotEmpty();
        RuleFor(c => c.ReorderLevel).NotEmpty();
        RuleFor(c => c.Discontinued).NotEmpty();
    }
}