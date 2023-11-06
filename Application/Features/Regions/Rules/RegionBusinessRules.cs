using Application.Features.Regions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Regions.Rules;

public class RegionBusinessRules : BaseBusinessRules
{
    private readonly IRegionRepository _regionRepository;

    public RegionBusinessRules(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public Task RegionShouldExistWhenSelected(Region? region)
    {
        if (region == null)
            throw new BusinessException(RegionsBusinessMessages.RegionNotExists);
        return Task.CompletedTask;
    }

    public async Task RegionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Region? region = await _regionRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RegionShouldExistWhenSelected(region);
    }
}