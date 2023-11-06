using Application.Features.UsStates.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsStates;

public class UsStatesManager : IUsStatesService
{
    private readonly IUsStateRepository _usStateRepository;
    private readonly UsStateBusinessRules _usStateBusinessRules;

    public UsStatesManager(IUsStateRepository usStateRepository, UsStateBusinessRules usStateBusinessRules)
    {
        _usStateRepository = usStateRepository;
        _usStateBusinessRules = usStateBusinessRules;
    }

    public async Task<UsState?> GetAsync(
        Expression<Func<UsState, bool>> predicate,
        Func<IQueryable<UsState>, IIncludableQueryable<UsState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UsState? usState = await _usStateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return usState;
    }

    public async Task<IPaginate<UsState>?> GetListAsync(
        Expression<Func<UsState, bool>>? predicate = null,
        Func<IQueryable<UsState>, IOrderedQueryable<UsState>>? orderBy = null,
        Func<IQueryable<UsState>, IIncludableQueryable<UsState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UsState> usStateList = await _usStateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return usStateList;
    }

    public async Task<UsState> AddAsync(UsState usState)
    {
        UsState addedUsState = await _usStateRepository.AddAsync(usState);

        return addedUsState;
    }

    public async Task<UsState> UpdateAsync(UsState usState)
    {
        UsState updatedUsState = await _usStateRepository.UpdateAsync(usState);

        return updatedUsState;
    }

    public async Task<UsState> DeleteAsync(UsState usState, bool permanent = false)
    {
        UsState deletedUsState = await _usStateRepository.DeleteAsync(usState);

        return deletedUsState;
    }
}
