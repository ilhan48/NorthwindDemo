using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Shippers.Queries.GetList;

public class GetListShipperQuery : IRequest<GetListResponse<GetListShipperListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListShippers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetShippers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShipperQueryHandler : IRequestHandler<GetListShipperQuery, GetListResponse<GetListShipperListItemDto>>
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public GetListShipperQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShipperListItemDto>> Handle(GetListShipperQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Shipper> shippers = await _shipperRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShipperListItemDto> response = _mapper.Map<GetListResponse<GetListShipperListItemDto>>(shippers);
            return response;
        }
    }
}