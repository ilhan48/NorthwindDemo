using Application.Features.Territories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Territories.Rules;

public class TerritoryBusinessRules : BaseBusinessRules
{
    private readonly ITerritoryRepository _territoryRepository;

    public TerritoryBusinessRules(ITerritoryRepository territoryRepository)
    {
        _territoryRepository = territoryRepository;
    }

    public Task TerritoryShouldExistWhenSelected(Territory? territory)
    {
        if (territory == null)
            throw new BusinessException(TerritoriesBusinessMessages.TerritoryNotExists);
        return Task.CompletedTask;
    }

    public async Task TerritoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Territory? territory = await _territoryRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TerritoryShouldExistWhenSelected(territory);
    }
}