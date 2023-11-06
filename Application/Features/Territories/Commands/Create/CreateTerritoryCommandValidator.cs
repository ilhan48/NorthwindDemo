using FluentValidation;

namespace Application.Features.Territories.Commands.Create;

public class CreateTerritoryCommandValidator : AbstractValidator<CreateTerritoryCommand>
{
    public CreateTerritoryCommandValidator()
    {
        RuleFor(c => c.TerritoryDescription).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
    }
}