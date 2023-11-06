using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Suppliers.Commands.Update;

public class UpdateSupplierCommand : IRequest<UpdatedSupplierResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
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

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdatedSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public UpdateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository,
                                         SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierBusinessRules = supplierBusinessRules;
        }

        public async Task<UpdatedSupplierResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _supplierRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);
            supplier = _mapper.Map(request, supplier);

            await _supplierRepository.UpdateAsync(supplier!);

            UpdatedSupplierResponse response = _mapper.Map<UpdatedSupplierResponse>(supplier);
            return response;
        }
    }
}