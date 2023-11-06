using FluentValidation;

namespace Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.TitleOfCourtesy).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.HireDate).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
        RuleFor(c => c.PostalCode).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.HomePhone).NotEmpty();
        RuleFor(c => c.Extension).NotEmpty();
        RuleFor(c => c.Notes).NotEmpty();
        RuleFor(c => c.ReportsTo).NotEmpty();
        RuleFor(c => c.PhotoPath).NotEmpty();
    }
}