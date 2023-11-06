using FluentValidation;

namespace Application.Features.CustomerDemographics.Commands.Update;

public class UpdateCustomerDemographicCommandValidator : AbstractValidator<UpdateCustomerDemographicCommand>
{
    public UpdateCustomerDemographicCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerTypeId).NotEmpty();
        RuleFor(c => c.CustomerDesc).NotEmpty();
    }
}