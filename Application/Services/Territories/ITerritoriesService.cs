using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Territories;

public interface ITerritoriesService
{
    Task<Territory?> GetAsync(
        Expression<Func<Territory, bool>> predicate,
        Func<IQueryable<Territory>, IIncludableQueryable<Territory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Territory>?> GetListAsync(
        Expression<Func<Territory, bool>>? predicate = null,
        Func<IQueryable<Territory>, IOrderedQueryable<Territory>>? orderBy = null,
        Func<IQueryable<Territory>, IIncludableQueryable<Territory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Territory> AddAsync(Territory territory);
    Task<Territory> UpdateAsync(Territory territory);
    Task<Territory> DeleteAsync(Territory territory, bool permanent = false);
}
