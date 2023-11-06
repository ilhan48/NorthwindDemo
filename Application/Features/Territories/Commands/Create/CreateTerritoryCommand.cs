using Application.Features.Territories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Territories.Commands.Create;

public class CreateTerritoryCommand : IRequest<CreatedTerritoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTerritories";

    public class CreateTerritoryCommandHandler : IRequestHandler<CreateTerritoryCommand, CreatedTerritoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly TerritoryBusinessRules _territoryBusinessRules;

        public CreateTerritoryCommandHandler(IMapper mapper, ITerritoryRepository territoryRepository,
                                         TerritoryBusinessRules territoryBusinessRules)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
            _territoryBusinessRules = territoryBusinessRules;
        }

        public async Task<CreatedTerritoryResponse> Handle(CreateTerritoryCommand request, CancellationToken cancellationToken)
        {
            Territory territory = _mapper.Map<Territory>(request);

            await _territoryRepository.AddAsync(territory);

            CreatedTerritoryResponse response = _mapper.Map<CreatedTerritoryResponse>(territory);
            return response;
        }
    }
}