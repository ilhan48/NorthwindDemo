using FluentValidation;

namespace Application.Features.Shippers.Commands.Delete;

public class DeleteShipperCommandValidator : AbstractValidator<DeleteShipperCommand>
{
    public DeleteShipperCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}