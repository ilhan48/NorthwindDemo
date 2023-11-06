using Application.Features.Shippers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shippers;

public class ShippersManager : IShippersService
{
    private readonly IShipperRepository _shipperRepository;
    private readonly ShipperBusinessRules _shipperBusinessRules;

    public ShippersManager(IShipperRepository shipperRepository, ShipperBusinessRules shipperBusinessRules)
    {
        _shipperRepository = shipperRepository;
        _shipperBusinessRules = shipperBusinessRules;
    }

    public async Task<Shipper?> GetAsync(
        Expression<Func<Shipper, bool>> predicate,
        Func<IQueryable<Shipper>, IIncludableQueryable<Shipper, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Shipper? shipper = await _shipperRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shipper;
    }

    public async Task<IPaginate<Shipper>?> GetListAsync(
        Expression<Func<Shipper, bool>>? predicate = null,
        Func<IQueryable<Shipper>, IOrderedQueryable<Shipper>>? orderBy = null,
        Func<IQueryable<Shipper>, IIncludableQueryable<Shipper, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Shipper> shipperList = await _shipperRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shipperList;
    }

    public async Task<Shipper> AddAsync(Shipper shipper)
    {
        Shipper addedShipper = await _shipperRepository.AddAsync(shipper);

        return addedShipper;
    }

    public async Task<Shipper> UpdateAsync(Shipper shipper)
    {
        Shipper updatedShipper = await _shipperRepository.UpdateAsync(shipper);

        return updatedShipper;
    }

    public async Task<Shipper> DeleteAsync(Shipper shipper, bool permanent = false)
    {
        Shipper deletedShipper = await _shipperRepository.DeleteAsync(shipper);

        return deletedShipper;
    }
}
