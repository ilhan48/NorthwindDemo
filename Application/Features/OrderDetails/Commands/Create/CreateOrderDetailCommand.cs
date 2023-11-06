using Application.Features.OrderDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.OrderDetails.Commands.Create;

public class CreateOrderDetailCommand : IRequest<CreatedOrderDetailResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public short OrderId { get; set; }
    public short ProductId { get; set; }
    public float UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetOrderDetails";

    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreatedOrderDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

        public CreateOrderDetailCommandHandler(IMapper mapper, IOrderDetailRepository orderDetailRepository,
                                         OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<CreatedOrderDetailResponse> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(request);

            await _orderDetailRepository.AddAsync(orderDetail);

            CreatedOrderDetailResponse response = _mapper.Map<CreatedOrderDetailResponse>(orderDetail);
            return response;
        }
    }
}