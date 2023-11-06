using Application.Features.Territories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Territories.Queries.GetById;

public class GetByIdTerritoryQuery : IRequest<GetByIdTerritoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTerritoryQueryHandler : IRequestHandler<GetByIdTerritoryQuery, GetByIdTerritoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly TerritoryBusinessRules _territoryBusinessRules;

        public GetByIdTerritoryQueryHandler(IMapper mapper, ITerritoryRepository territoryRepository, TerritoryBusinessRules territoryBusinessRules)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
            _territoryBusinessRules = territoryBusinessRules;
        }

        public async Task<GetByIdTerritoryResponse> Handle(GetByIdTerritoryQuery request, CancellationToken cancellationToken)
        {
            Territory? territory = await _territoryRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _territoryBusinessRules.TerritoryShouldExistWhenSelected(territory);

            GetByIdTerritoryResponse response = _mapper.Map<GetByIdTerritoryResponse>(territory);
            return response;
        }
    }
}