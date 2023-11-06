using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.EmployeeId).NotEmpty();
        RuleFor(c => c.OrderDate).NotEmpty();
        RuleFor(c => c.RequiredDate).NotEmpty();
        RuleFor(c => c.ShippedDate).NotEmpty();
        RuleFor(c => c.ShipVia).NotEmpty();
        RuleFor(c => c.Freight).NotEmpty();
        RuleFor(c => c.ShipName).NotEmpty();
        RuleFor(c => c.ShipAddress).NotEmpty();
        RuleFor(c => c.ShipCity).NotEmpty();
        RuleFor(c => c.ShipRegion).NotEmpty();
        RuleFor(c => c.ShipPostalCode).NotEmpty();
        RuleFor(c => c.ShipCountry).NotEmpty();
    }
}