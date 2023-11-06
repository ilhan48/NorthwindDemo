using FluentValidation;

namespace Application.Features.UsStates.Commands.Delete;

public class DeleteUsStateCommandValidator : AbstractValidator<DeleteUsStateCommand>
{
    public DeleteUsStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}