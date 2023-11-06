using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<CreatedEmployeeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Title { get; set; }
    public string? TitleOfCourtesy { get; set; }
    public DateOnly? BirthDate { get; set; }
    public DateOnly? HireDate { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? HomePhone { get; set; }
    public string? Extension { get; set; }
    public string? Notes { get; set; }
    public short? ReportsTo { get; set; }
    public string? PhotoPath { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEmployees";

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository,
                                         EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);

            CreatedEmployeeResponse response = _mapper.Map<CreatedEmployeeResponse>(employee);
            return response;
        }
    }
}