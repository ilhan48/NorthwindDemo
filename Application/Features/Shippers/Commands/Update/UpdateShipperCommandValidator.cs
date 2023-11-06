using FluentValidation;

namespace Application.Features.Shippers.Commands.Update;

public class UpdateShipperCommandValidator : AbstractValidator<UpdateShipperCommand>
{
    public UpdateShipperCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}