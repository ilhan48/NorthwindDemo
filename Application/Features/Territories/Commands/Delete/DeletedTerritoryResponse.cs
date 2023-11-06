using Core.Application.Responses;

namespace Application.Features.Territories.Commands.Delete;

public class DeletedTerritoryResponse : IResponse
{
    public Guid Id { get; set; }
}