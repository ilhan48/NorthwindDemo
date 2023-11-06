using Application.Features.OrderDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.OrderDetails.Rules;

public class OrderDetailBusinessRules : BaseBusinessRules
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailBusinessRules(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public Task OrderDetailShouldExistWhenSelected(OrderDetail? orderDetail)
    {
        if (orderDetail == null)
            throw new BusinessException(OrderDetailsBusinessMessages.OrderDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task OrderDetailIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderDetail? orderDetail = await _orderDetailRepository.GetAsync(
            predicate: od => od.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderDetailShouldExistWhenSelected(orderDetail);
    }
}