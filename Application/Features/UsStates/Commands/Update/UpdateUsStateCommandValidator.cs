using FluentValidation;

namespace Application.Features.UsStates.Commands.Update;

public class UpdateUsStateCommandValidator : AbstractValidator<UpdateUsStateCommand>
{
    public UpdateUsStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StateName).NotEmpty();
        RuleFor(c => c.StateAbbr).NotEmpty();
        RuleFor(c => c.StateRegion).NotEmpty();
    }
}