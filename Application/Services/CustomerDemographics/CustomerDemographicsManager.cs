using Application.Features.CustomerDemographics.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerDemographics;

public class CustomerDemographicsManager : ICustomerDemographicsService
{
    private readonly ICustomerDemographicRepository _customerDemographicRepository;
    private readonly CustomerDemographicBusinessRules _customerDemographicBusinessRules;

    public CustomerDemographicsManager(ICustomerDemographicRepository customerDemographicRepository, CustomerDemographicBusinessRules customerDemographicBusinessRules)
    {
        _customerDemographicRepository = customerDemographicRepository;
        _customerDemographicBusinessRules = customerDemographicBusinessRules;
    }

    public async Task<CustomerDemographic?> GetAsync(
        Expression<Func<CustomerDemographic, bool>> predicate,
        Func<IQueryable<CustomerDemographic>, IIncludableQueryable<CustomerDemographic, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerDemographic? customerDemographic = await _customerDemographicRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerDemographic;
    }

    public async Task<IPaginate<CustomerDemographic>?> GetListAsync(
        Expression<Func<CustomerDemographic, bool>>? predicate = null,
        Func<IQueryable<CustomerDemographic>, IOrderedQueryable<CustomerDemographic>>? orderBy = null,
        Func<IQueryable<CustomerDemographic>, IIncludableQueryable<CustomerDemographic, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerDemographic> customerDemographicList = await _customerDemographicRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerDemographicList;
    }

    public async Task<CustomerDemographic> AddAsync(CustomerDemographic customerDemographic)
    {
        CustomerDemographic addedCustomerDemographic = await _customerDemographicRepository.AddAsync(customerDemographic);

        return addedCustomerDemographic;
    }

    public async Task<CustomerDemographic> UpdateAsync(CustomerDemographic customerDemographic)
    {
        CustomerDemographic updatedCustomerDemographic = await _customerDemographicRepository.UpdateAsync(customerDemographic);

        return updatedCustomerDemographic;
    }

    public async Task<CustomerDemographic> DeleteAsync(CustomerDemographic customerDemographic, bool permanent = false)
    {
        CustomerDemographic deletedCustomerDemographic = await _customerDemographicRepository.DeleteAsync(customerDemographic);

        return deletedCustomerDemographic;
    }
}
