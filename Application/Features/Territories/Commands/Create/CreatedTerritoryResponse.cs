using Core.Application.Responses;

namespace Application.Features.Territories.Commands.Create;

public class CreatedTerritoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }
}