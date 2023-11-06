using Core.Application.Responses;

namespace Application.Features.OrderDetails.Commands.Delete;

public class DeletedOrderDetailResponse : IResponse
{
    public Guid Id { get; set; }
}