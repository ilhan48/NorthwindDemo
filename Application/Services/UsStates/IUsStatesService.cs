using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsStates;

public interface IUsStatesService
{
    Task<UsState?> GetAsync(
        Expression<Func<UsState, bool>> predicate,
        Func<IQueryable<UsState>, IIncludableQueryable<UsState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UsState>?> GetListAsync(
        Expression<Func<UsState, bool>>? predicate = null,
        Func<IQueryable<UsState>, IOrderedQueryable<UsState>>? orderBy = null,
        Func<IQueryable<UsState>, IIncludableQueryable<UsState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UsState> AddAsync(UsState usState);
    Task<UsState> UpdateAsync(UsState usState);
    Task<UsState> DeleteAsync(UsState usState, bool permanent = false);
}
