using Core.Application.Dtos;

namespace Application.Features.UsStates.Queries.GetList;

public class GetListUsStateListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? StateName { get; set; }
    public string? StateAbbr { get; set; }
    public string? StateRegion { get; set; }
}