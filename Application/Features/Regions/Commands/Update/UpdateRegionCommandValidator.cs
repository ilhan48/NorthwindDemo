using FluentValidation;

namespace Application.Features.Regions.Commands.Update;

public class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RegionDescription).NotEmpty();
    }
}