using Application.Features.Shippers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Shippers.Commands.Update;

public class UpdateShipperCommand : IRequest<UpdatedShipperResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippers";

    public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, UpdatedShipperResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipperRepository _shipperRepository;
        private readonly ShipperBusinessRules _shipperBusinessRules;

        public UpdateShipperCommandHandler(IMapper mapper, IShipperRepository shipperRepository,
                                         ShipperBusinessRules shipperBusinessRules)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
            _shipperBusinessRules = shipperBusinessRules;
        }

        public async Task<UpdatedShipperResponse> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
        {
            Shipper? shipper = await _shipperRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipperBusinessRules.ShipperShouldExistWhenSelected(shipper);
            shipper = _mapper.Map(request, shipper);

            await _shipperRepository.UpdateAsync(shipper!);

            UpdatedShipperResponse response = _mapper.Map<UpdatedShipperResponse>(shipper);
            return response;
        }
    }
}