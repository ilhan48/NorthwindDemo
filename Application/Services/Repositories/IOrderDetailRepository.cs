using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderDetailRepository : IAsyncRepository<OrderDetail, Guid>, IRepository<OrderDetail, Guid>
{
}