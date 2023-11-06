using Core.Application.Responses;

namespace Application.Features.Shippers.Commands.Delete;

public class DeletedShipperResponse : IResponse
{
    public Guid Id { get; set; }
}