using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CustomerDemographics.Queries.GetList;

public class GetListCustomerDemographicQuery : IRequest<GetListResponse<GetListCustomerDemographicListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomerDemographics({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomerDemographics";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerDemographicQueryHandler : IRequestHandler<GetListCustomerDemographicQuery, GetListResponse<GetListCustomerDemographicListItemDto>>
    {
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly IMapper _mapper;

        public GetListCustomerDemographicQueryHandler(ICustomerDemographicRepository customerDemographicRepository, IMapper mapper)
        {
            _customerDemographicRepository = customerDemographicRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerDemographicListItemDto>> Handle(GetListCustomerDemographicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerDemographic> customerDemographics = await _customerDemographicRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerDemographicListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerDemographicListItemDto>>(customerDemographics);
            return response;
        }
    }
}