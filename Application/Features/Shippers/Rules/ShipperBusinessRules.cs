using Application.Features.Shippers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Shippers.Rules;

public class ShipperBusinessRules : BaseBusinessRules
{
    private readonly IShipperRepository _shipperRepository;

    public ShipperBusinessRules(IShipperRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public Task ShipperShouldExistWhenSelected(Shipper? shipper)
    {
        if (shipper == null)
            throw new BusinessException(ShippersBusinessMessages.ShipperNotExists);
        return Task.CompletedTask;
    }

    public async Task ShipperIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Shipper? shipper = await _shipperRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShipperShouldExistWhenSelected(shipper);
    }
}