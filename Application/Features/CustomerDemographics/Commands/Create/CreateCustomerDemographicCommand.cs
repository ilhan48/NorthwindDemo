using Application.Features.CustomerDemographics.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CustomerDemographics.Commands.Create;

public class CreateCustomerDemographicCommand : IRequest<CreatedCustomerDemographicResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerDemographics";

    public class CreateCustomerDemographicCommandHandler : IRequestHandler<CreateCustomerDemographicCommand, CreatedCustomerDemographicResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly CustomerDemographicBusinessRules _customerDemographicBusinessRules;

        public CreateCustomerDemographicCommandHandler(IMapper mapper, ICustomerDemographicRepository customerDemographicRepository,
                                         CustomerDemographicBusinessRules customerDemographicBusinessRules)
        {
            _mapper = mapper;
            _customerDemographicRepository = customerDemographicRepository;
            _customerDemographicBusinessRules = customerDemographicBusinessRules;
        }

        public async Task<CreatedCustomerDemographicResponse> Handle(CreateCustomerDemographicCommand request, CancellationToken cancellationToken)
        {
            CustomerDemographic customerDemographic = _mapper.Map<CustomerDemographic>(request);

            await _customerDemographicRepository.AddAsync(customerDemographic);

            CreatedCustomerDemographicResponse response = _mapper.Map<CreatedCustomerDemographicResponse>(customerDemographic);
            return response;
        }
    }
}