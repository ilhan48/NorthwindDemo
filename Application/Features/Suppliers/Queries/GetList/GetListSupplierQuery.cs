using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Suppliers.Queries.GetList;

public class GetListSupplierQuery : IRequest<GetListResponse<GetListSupplierListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSuppliers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSuppliers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSupplierQueryHandler : IRequestHandler<GetListSupplierQuery, GetListResponse<GetListSupplierListItemDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetListSupplierQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSupplierListItemDto>> Handle(GetListSupplierQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Supplier> suppliers = await _supplierRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSupplierListItemDto> response = _mapper.Map<GetListResponse<GetListSupplierListItemDto>>(suppliers);
            return response;
        }
    }
}