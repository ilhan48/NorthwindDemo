using Core.Application.Dtos;

namespace Application.Features.Territories.Queries.GetList;

public class GetListTerritoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }
}