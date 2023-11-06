using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Territories.Queries.GetList;

public class GetListTerritoryQuery : IRequest<GetListResponse<GetListTerritoryListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListTerritories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetTerritories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTerritoryQueryHandler : IRequestHandler<GetListTerritoryQuery, GetListResponse<GetListTerritoryListItemDto>>
    {
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IMapper _mapper;

        public GetListTerritoryQueryHandler(ITerritoryRepository territoryRepository, IMapper mapper)
        {
            _territoryRepository = territoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTerritoryListItemDto>> Handle(GetListTerritoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Territory> territories = await _territoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTerritoryListItemDto> response = _mapper.Map<GetListResponse<GetListTerritoryListItemDto>>(territories);
            return response;
        }
    }
}