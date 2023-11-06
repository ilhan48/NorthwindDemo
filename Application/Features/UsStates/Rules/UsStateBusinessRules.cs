using Application.Features.UsStates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UsStates.Rules;

public class UsStateBusinessRules : BaseBusinessRules
{
    private readonly IUsStateRepository _usStateRepository;

    public UsStateBusinessRules(IUsStateRepository usStateRepository)
    {
        _usStateRepository = usStateRepository;
    }

    public Task UsStateShouldExistWhenSelected(UsState? usState)
    {
        if (usState == null)
            throw new BusinessException(UsStatesBusinessMessages.UsStateNotExists);
        return Task.CompletedTask;
    }

    public async Task UsStateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UsState? usState = await _usStateRepository.GetAsync(
            predicate: us => us.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UsStateShouldExistWhenSelected(usState);
    }
}