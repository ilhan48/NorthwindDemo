using Application.Features.CustomerDemographics.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CustomerDemographics.Commands.Update;

public class UpdateCustomerDemographicCommand : IRequest<UpdatedCustomerDemographicResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerDemographics";

    public class UpdateCustomerDemographicCommandHandler : IRequestHandler<UpdateCustomerDemographicCommand, UpdatedCustomerDemographicResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly CustomerDemographicBusinessRules _customerDemographicBusinessRules;

        public UpdateCustomerDemographicCommandHandler(IMapper mapper, ICustomerDemographicRepository customerDemographicRepository,
                                         CustomerDemographicBusinessRules customerDemographicBusinessRules)
        {
            _mapper = mapper;
            _customerDemographicRepository = customerDemographicRepository;
            _customerDemographicBusinessRules = customerDemographicBusinessRules;
        }

        public async Task<UpdatedCustomerDemographicResponse> Handle(UpdateCustomerDemographicCommand request, CancellationToken cancellationToken)
        {
            CustomerDemographic? customerDemographic = await _customerDemographicRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerDemographicBusinessRules.CustomerDemographicShouldExistWhenSelected(customerDemographic);
            customerDemographic = _mapper.Map(request, customerDemographic);

            await _customerDemographicRepository.UpdateAsync(customerDemographic!);

            UpdatedCustomerDemographicResponse response = _mapper.Map<UpdatedCustomerDemographicResponse>(customerDemographic);
            return response;
        }
    }
}