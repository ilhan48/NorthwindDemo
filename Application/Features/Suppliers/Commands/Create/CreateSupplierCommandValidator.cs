using FluentValidation;

namespace Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.ContactName).NotEmpty();
        RuleFor(c => c.ContactTitle).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
        RuleFor(c => c.PostalCode).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Fax).NotEmpty();
        RuleFor(c => c.Homepage).NotEmpty();
    }
}