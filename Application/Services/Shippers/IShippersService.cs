using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shippers;

public interface IShippersService
{
    Task<Shipper?> GetAsync(
        Expression<Func<Shipper, bool>> predicate,
        Func<IQueryable<Shipper>, IIncludableQueryable<Shipper, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Shipper>?> GetListAsync(
        Expression<Func<Shipper, bool>>? predicate = null,
        Func<IQueryable<Shipper>, IOrderedQueryable<Shipper>>? orderBy = null,
        Func<IQueryable<Shipper>, IIncludableQueryable<Shipper, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Shipper> AddAsync(Shipper shipper);
    Task<Shipper> UpdateAsync(Shipper shipper);
    Task<Shipper> DeleteAsync(Shipper shipper, bool permanent = false);
}
