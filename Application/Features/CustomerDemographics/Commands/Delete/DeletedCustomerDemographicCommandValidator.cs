using FluentValidation;

namespace Application.Features.CustomerDemographics.Commands.Delete;

public class DeleteCustomerDemographicCommandValidator : AbstractValidator<DeleteCustomerDemographicCommand>
{
    public DeleteCustomerDemographicCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}