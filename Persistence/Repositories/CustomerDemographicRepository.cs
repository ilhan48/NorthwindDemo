using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerDemographicRepository : EfRepositoryBase<CustomerDemographic, Guid, BaseDbContext>, ICustomerDemographicRepository
{
    public CustomerDemographicRepository(BaseDbContext context) : base(context)
    {
    }
}