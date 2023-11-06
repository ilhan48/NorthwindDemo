using Application.Features.Territories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Territories.Commands.Update;

public class UpdateTerritoryCommand : IRequest<UpdatedTerritoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTerritories";

    public class UpdateTerritoryCommandHandler : IRequestHandler<UpdateTerritoryCommand, UpdatedTerritoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly TerritoryBusinessRules _territoryBusinessRules;

        public UpdateTerritoryCommandHandler(IMapper mapper, ITerritoryRepository territoryRepository,
                                         TerritoryBusinessRules territoryBusinessRules)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
            _territoryBusinessRules = territoryBusinessRules;
        }

        public async Task<UpdatedTerritoryResponse> Handle(UpdateTerritoryCommand request, CancellationToken cancellationToken)
        {
            Territory? territory = await _territoryRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _territoryBusinessRules.TerritoryShouldExistWhenSelected(territory);
            territory = _mapper.Map(request, territory);

            await _territoryRepository.UpdateAsync(territory!);

            UpdatedTerritoryResponse response = _mapper.Map<UpdatedTerritoryResponse>(territory);
            return response;
        }
    }
}