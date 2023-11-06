using Core.Application.Responses;

namespace Application.Features.OrderDetails.Commands.Create;

public class CreatedOrderDetailResponse : IResponse
{
    public Guid Id { get; set; }
    public short OrderId { get; set; }
    public short ProductId { get; set; }
    public float UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}