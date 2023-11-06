using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommand : IRequest<CreatedSupplierResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string CompanyName { get; set; }
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Homepage { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSuppliers";

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreatedSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public CreateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository,
                                         SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierBusinessRules = supplierBusinessRules;
        }

        public async Task<CreatedSupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier supplier = _mapper.Map<Supplier>(request);

            await _supplierRepository.AddAsync(supplier);

            CreatedSupplierResponse response = _mapper.Map<CreatedSupplierResponse>(supplier);
            return response;
        }
    }
}