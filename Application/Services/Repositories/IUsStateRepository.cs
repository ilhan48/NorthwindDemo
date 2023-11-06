using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUsStateRepository : IAsyncRepository<UsState, Guid>, IRepository<UsState, Guid>
{
}