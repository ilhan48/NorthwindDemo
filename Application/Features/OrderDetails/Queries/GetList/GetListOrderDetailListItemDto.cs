using Core.Application.Dtos;

namespace Application.Features.OrderDetails.Queries.GetList;

public class GetListOrderDetailListItemDto : IDto
{
    public Guid Id { get; set; }
    public short OrderId { get; set; }
    public short ProductId { get; set; }
    public float UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}