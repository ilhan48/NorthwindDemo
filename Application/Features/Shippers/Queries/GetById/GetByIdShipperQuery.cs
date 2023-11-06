using Application.Features.Shippers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shippers.Queries.GetById;

public class GetByIdShipperQuery : IRequest<GetByIdShipperResponse>
{
    public Guid Id { get; set; }

    public class GetByIdShipperQueryHandler : IRequestHandler<GetByIdShipperQuery, GetByIdShipperResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShipperRepository _shipperRepository;
        private readonly ShipperBusinessRules _shipperBusinessRules;

        public GetByIdShipperQueryHandler(IMapper mapper, IShipperRepository shipperRepository, ShipperBusinessRules shipperBusinessRules)
        {
            _mapper = mapper;
            _shipperRepository = shipperRepository;
            _shipperBusinessRules = shipperBusinessRules;
        }

        public async Task<GetByIdShipperResponse> Handle(GetByIdShipperQuery request, CancellationToken cancellationToken)
        {
            Shipper? shipper = await _shipperRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shipperBusinessRules.ShipperShouldExistWhenSelected(shipper);

            GetByIdShipperResponse response = _mapper.Map<GetByIdShipperResponse>(shipper);
            return response;
        }
    }
}