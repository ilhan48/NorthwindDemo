using FluentValidation;

namespace Application.Features.Regions.Commands.Create;

public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(c => c.RegionDescription).NotEmpty();
    }
}