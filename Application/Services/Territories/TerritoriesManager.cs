using Application.Features.Territories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Territories;

public class TerritoriesManager : ITerritoriesService
{
    private readonly ITerritoryRepository _territoryRepository;
    private readonly TerritoryBusinessRules _territoryBusinessRules;

    public TerritoriesManager(ITerritoryRepository territoryRepository, TerritoryBusinessRules territoryBusinessRules)
    {
        _territoryRepository = territoryRepository;
        _territoryBusinessRules = territoryBusinessRules;
    }

    public async Task<Territory?> GetAsync(
        Expression<Func<Territory, bool>> predicate,
        Func<IQueryable<Territory>, IIncludableQueryable<Territory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Territory? territory = await _territoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return territory;
    }

    public async Task<IPaginate<Territory>?> GetListAsync(
        Expression<Func<Territory, bool>>? predicate = null,
        Func<IQueryable<Territory>, IOrderedQueryable<Territory>>? orderBy = null,
        Func<IQueryable<Territory>, IIncludableQueryable<Territory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Territory> territoryList = await _territoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return territoryList;
    }

    public async Task<Territory> AddAsync(Territory territory)
    {
        Territory addedTerritory = await _territoryRepository.AddAsync(territory);

        return addedTerritory;
    }

    public async Task<Territory> UpdateAsync(Territory territory)
    {
        Territory updatedTerritory = await _territoryRepository.UpdateAsync(territory);

        return updatedTerritory;
    }

    public async Task<Territory> DeleteAsync(Territory territory, bool permanent = false)
    {
        Territory deletedTerritory = await _territoryRepository.DeleteAsync(territory);

        return deletedTerritory;
    }
}
