using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerDemographicRepository : IAsyncRepository<CustomerDemographic, Guid>, IRepository<CustomerDemographic, Guid>
{
}