using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITerritoryRepository : IAsyncRepository<Territory, Guid>, IRepository<Territory, Guid>
{
}