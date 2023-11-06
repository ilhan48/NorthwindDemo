using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RegionRepository : EfRepositoryBase<Region, Guid, BaseDbContext>, IRegionRepository
{
    public RegionRepository(BaseDbContext context) : base(context)
    {
    }
}