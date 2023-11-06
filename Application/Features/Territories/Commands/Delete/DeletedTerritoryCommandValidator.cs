using FluentValidation;

namespace Application.Features.Territories.Commands.Delete;

public class DeleteTerritoryCommandValidator : AbstractValidator<DeleteTerritoryCommand>
{
    public DeleteTerritoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}