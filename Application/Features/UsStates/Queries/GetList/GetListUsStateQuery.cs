using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UsStates.Queries.GetList;

public class GetListUsStateQuery : IRequest<GetListResponse<GetListUsStateListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListUsStates({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetUsStates";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUsStateQueryHandler : IRequestHandler<GetListUsStateQuery, GetListResponse<GetListUsStateListItemDto>>
    {
        private readonly IUsStateRepository _usStateRepository;
        private readonly IMapper _mapper;

        public GetListUsStateQueryHandler(IUsStateRepository usStateRepository, IMapper mapper)
        {
            _usStateRepository = usStateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUsStateListItemDto>> Handle(GetListUsStateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UsState> usStates = await _usStateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUsStateListItemDto> response = _mapper.Map<GetListResponse<GetListUsStateListItemDto>>(usStates);
            return response;
        }
    }
}