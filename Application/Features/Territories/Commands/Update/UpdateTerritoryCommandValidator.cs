using FluentValidation;

namespace Application.Features.Territories.Commands.Update;

public class UpdateTerritoryCommandValidator : AbstractValidator<UpdateTerritoryCommand>
{
    public UpdateTerritoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TerritoryDescription).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
    }
}