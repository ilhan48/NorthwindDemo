using FluentValidation;

namespace Application.Features.OrderDetails.Commands.Update;

public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
{
    public UpdateOrderDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.Discount).NotEmpty();
    }
}