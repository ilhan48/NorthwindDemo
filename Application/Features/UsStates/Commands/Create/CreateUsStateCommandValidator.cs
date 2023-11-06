using FluentValidation;

namespace Application.Features.UsStates.Commands.Create;

public class CreateUsStateCommandValidator : AbstractValidator<CreateUsStateCommand>
{
    public CreateUsStateCommandValidator()
    {
        RuleFor(c => c.StateName).NotEmpty();
        RuleFor(c => c.StateAbbr).NotEmpty();
        RuleFor(c => c.StateRegion).NotEmpty();
    }
}