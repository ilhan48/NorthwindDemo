using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, Guid>, IRepository<Customer, Guid>
{
}