using FluentValidation;

namespace Application.Features.CustomerDemographics.Commands.Create;

public class CreateCustomerDemographicCommandValidator : AbstractValidator<CreateCustomerDemographicCommand>
{
    public CreateCustomerDemographicCommandValidator()
    {
        RuleFor(c => c.CustomerTypeId).NotEmpty();
        RuleFor(c => c.CustomerDesc).NotEmpty();
    }
}