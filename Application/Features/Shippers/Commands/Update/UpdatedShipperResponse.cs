using Core.Application.Responses;

namespace Application.Features.Shippers.Commands.Update;

public class UpdatedShipperResponse : IResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }
}