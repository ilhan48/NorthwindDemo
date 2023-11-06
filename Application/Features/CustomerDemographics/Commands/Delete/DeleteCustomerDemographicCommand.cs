using Application.Features.CustomerDemographics.Constants;
using Application.Features.CustomerDemographics.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CustomerDemographics.Commands.Delete;

public class DeleteCustomerDemographicCommand : IRequest<DeletedCustomerDemographicResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerDemographics";

    public class DeleteCustomerDemographicCommandHandler : IRequestHandler<DeleteCustomerDemographicCommand, DeletedCustomerDemographicResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly CustomerDemographicBusinessRules _customerDemographicBusinessRules;

        public DeleteCustomerDemographicCommandHandler(IMapper mapper, ICustomerDemographicRepository customerDemographicRepository,
                                         CustomerDemographicBusinessRules customerDemographicBusinessRules)
        {
            _mapper = mapper;
            _customerDemographicRepository = customerDemographicRepository;
            _customerDemographicBusinessRules = customerDemographicBusinessRules;
        }

        public async Task<DeletedCustomerDemographicResponse> Handle(DeleteCustomerDemographicCommand request, CancellationToken cancellationToken)
        {
            CustomerDemographic? customerDemographic = await _customerDemographicRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerDemographicBusinessRules.CustomerDemographicShouldExistWhenSelected(customerDemographic);

            await _customerDemographicRepository.DeleteAsync(customerDemographic!);

            DeletedCustomerDemographicResponse response = _mapper.Map<DeletedCustomerDemographicResponse>(customerDemographic);
            return response;
        }
    }
}