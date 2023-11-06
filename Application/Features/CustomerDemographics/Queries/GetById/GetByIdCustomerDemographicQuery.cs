using Application.Features.CustomerDemographics.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomerDemographics.Queries.GetById;

public class GetByIdCustomerDemographicQuery : IRequest<GetByIdCustomerDemographicResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCustomerDemographicQueryHandler : IRequestHandler<GetByIdCustomerDemographicQuery, GetByIdCustomerDemographicResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly CustomerDemographicBusinessRules _customerDemographicBusinessRules;

        public GetByIdCustomerDemographicQueryHandler(IMapper mapper, ICustomerDemographicRepository customerDemographicRepository, CustomerDemographicBusinessRules customerDemographicBusinessRules)
        {
            _mapper = mapper;
            _customerDemographicRepository = customerDemographicRepository;
            _customerDemographicBusinessRules = customerDemographicBusinessRules;
        }

        public async Task<GetByIdCustomerDemographicResponse> Handle(GetByIdCustomerDemographicQuery request, CancellationToken cancellationToken)
        {
            CustomerDemographic? customerDemographic = await _customerDemographicRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _customerDemographicBusinessRules.CustomerDemographicShouldExistWhenSelected(customerDemographic);

            GetByIdCustomerDemographicResponse response = _mapper.Map<GetByIdCustomerDemographicResponse>(customerDemographic);
            return response;
        }
    }
}