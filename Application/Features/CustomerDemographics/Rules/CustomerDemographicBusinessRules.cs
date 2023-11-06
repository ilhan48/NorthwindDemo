using Application.Features.CustomerDemographics.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerDemographics.Rules;

public class CustomerDemographicBusinessRules : BaseBusinessRules
{
    private readonly ICustomerDemographicRepository _customerDemographicRepository;

    public CustomerDemographicBusinessRules(ICustomerDemographicRepository customerDemographicRepository)
    {
        _customerDemographicRepository = customerDemographicRepository;
    }

    public Task CustomerDemographicShouldExistWhenSelected(CustomerDemographic? customerDemographic)
    {
        if (customerDemographic == null)
            throw new BusinessException(CustomerDemographicsBusinessMessages.CustomerDemographicNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerDemographicIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CustomerDemographic? customerDemographic = await _customerDemographicRepository.GetAsync(
            predicate: cd => cd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerDemographicShouldExistWhenSelected(customerDemographic);
    }
}