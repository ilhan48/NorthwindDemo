using Application.Features.Shippers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Shippers.Commands.Create;

public class CreateShipperCommand : IRequest<CreatedShipperResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string CompanyName { get; set; }
    public string? Phone { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShippers";

    public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommand, CreatedShipperResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipperRepository _shipperRepository;
        private readonly ShipperBusinessRules _shipperBusinessRules;

        public CreateShipperCommandHandler(IMapper mapper, IShipperRepository shipperRepository,
                                         ShipperBusinessRules shipperBusinessRules)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
            _shipperBusinessRules = shipperBusinessRules;
        }

        public async Task<CreatedShipperResponse> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
        {
            Shipper shipper = _mapper.Map<Shipper>(request);

            await _shipperRepository.AddAsync(shipper);

            CreatedShipperResponse response = _mapper.Map<CreatedShipperResponse>(shipper);
            return response;
        }
    }
}