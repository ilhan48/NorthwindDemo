using Application.Features.Suppliers.Constants;
using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Suppliers.Commands.Delete;

public class DeleteSupplierCommand : IRequest<DeletedSupplierResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSuppliers";

    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, DeletedSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public DeleteSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository,
                                         SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierBusinessRules = supplierBusinessRules;
        }

        public async Task<DeletedSupplierResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _supplierRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);

            await _supplierRepository.DeleteAsync(supplier!);

            DeletedSupplierResponse response = _mapper.Map<DeletedSupplierResponse>(supplier);
            return response;
        }
    }
}