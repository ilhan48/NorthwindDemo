using Application.Features.Territories.Constants;
using Application.Features.Territories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Territories.Commands.Delete;

public class DeleteTerritoryCommand : IRequest<DeletedTerritoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetTerritories";

    public class DeleteTerritoryCommandHandler : IRequestHandler<DeleteTerritoryCommand, DeletedTerritoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly TerritoryBusinessRules _territoryBusinessRules;

        public DeleteTerritoryCommandHandler(IMapper mapper, ITerritoryRepository territoryRepository,
                                         TerritoryBusinessRules territoryBusinessRules)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
            _territoryBusinessRules = territoryBusinessRules;
        }

        public async Task<DeletedTerritoryResponse> Handle(DeleteTerritoryCommand request, CancellationToken cancellationToken)
        {
            Territory? territory = await _territoryRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _territoryBusinessRules.TerritoryShouldExistWhenSelected(territory);

            await _territoryRepository.DeleteAsync(territory!);

            DeletedTerritoryResponse response = _mapper.Map<DeletedTerritoryResponse>(territory);
            return response;
        }
    }
}