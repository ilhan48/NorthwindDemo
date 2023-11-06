using FluentValidation;

namespace Application.Features.Shippers.Commands.Create;

public class CreateShipperCommandValidator : AbstractValidator<CreateShipperCommand>
{
    public CreateShipperCommandValidator()
    {
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}