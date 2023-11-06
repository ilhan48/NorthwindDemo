using Core.Application.Dtos;

namespace Application.Features.Regions.Queries.GetList;

public class GetListRegionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string RegionDescription { get; set; }
}