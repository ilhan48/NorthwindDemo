using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerDemographics;

public interface ICustomerDemographicsService
{
    Task<CustomerDemographic?> GetAsync(
        Expression<Func<CustomerDemographic, bool>> predicate,
        Func<IQueryable<CustomerDemographic>, IIncludableQueryable<CustomerDemographic, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerDemographic>?> GetListAsync(
        Expression<Func<CustomerDemographic, bool>>? predicate = null,
        Func<IQueryable<CustomerDemographic>, IOrderedQueryable<CustomerDemographic>>? orderBy = null,
        Func<IQueryable<CustomerDemographic>, IIncludableQueryable<CustomerDemographic, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerDemographic> AddAsync(CustomerDemographic customerDemographic);
    Task<CustomerDemographic> UpdateAsync(CustomerDemographic customerDemographic);
    Task<CustomerDemographic> DeleteAsync(CustomerDemographic customerDemographic, bool permanent = false);
}
