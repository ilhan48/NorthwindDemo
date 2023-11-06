using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UsStateRepository : EfRepositoryBase<UsState, Guid, BaseDbContext>, IUsStateRepository
{
    public UsStateRepository(BaseDbContext context) : base(context)
    {
    }
}