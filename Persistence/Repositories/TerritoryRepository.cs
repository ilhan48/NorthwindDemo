using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TerritoryRepository : EfRepositoryBase<Territory, Guid, BaseDbContext>, ITerritoryRepository
{
    public TerritoryRepository(BaseDbContext context) : base(context)
    {
    }
}