using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShipperRepository : EfRepositoryBase<Shipper, Guid, BaseDbContext>, IShipperRepository
{
    public ShipperRepository(BaseDbContext context) : base(context)
    {
    }
}