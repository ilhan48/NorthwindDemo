using Core.Application.Responses;

namespace Application.Features.Territories.Commands.Update;

public class UpdatedTerritoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }
}