using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShipperRepository : IAsyncRepository<Shipper, Guid>, IRepository<Shipper, Guid>
{
}