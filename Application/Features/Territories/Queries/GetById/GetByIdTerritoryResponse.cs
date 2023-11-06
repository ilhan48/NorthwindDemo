using Core.Application.Responses;

namespace Application.Features.Territories.Queries.GetById;

public class GetByIdTerritoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string TerritoryDescription { get; set; }
    public short RegionId { get; set; }
}