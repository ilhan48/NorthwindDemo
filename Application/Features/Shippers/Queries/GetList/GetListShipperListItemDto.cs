using Core.Application.Dtos;

namespace Application.Features.Shippers.Queries.GetList;

public class GetListShipperListItemDto : IDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }
}