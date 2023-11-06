using Core.Application.Responses;

namespace Application.Features.Shippers.Commands.Create;

public class CreatedShipperResponse : IResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }
}