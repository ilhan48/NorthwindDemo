using Core.Application.Responses;

namespace Application.Features.Shippers.Queries.GetById;

public class GetByIdShipperResponse : IResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }
}