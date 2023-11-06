using Application.Features.Shippers.Constants;
using Application.Features.Shippers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Shippers.Commands.Delete;

public class DeleteShipperCommand : IRequest<DeletedShipperResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippers";

    public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand, DeletedShipperResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipperRepository _shipperRepository;
        private readonly ShipperBusinessRules _shipperBusinessRules;

        public DeleteShipperCommandHandler(IMapper mapper, IShipperRepository shipperRepository,
                                         ShipperBusinessRules shipperBusinessRules)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
            _shipperBusinessRules = shipperBusinessRules;
        }

        public async Task<DeletedShipperResponse> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
        {
            Shipper? shipper = await _shipperRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipperBusinessRules.ShipperShouldExistWhenSelected(shipper);

            await _shipperRepository.DeleteAsync(shipper!);

            DeletedShipperResponse response = _mapper.Map<DeletedShipperResponse>(shipper);
            return response;
        }
    }
}