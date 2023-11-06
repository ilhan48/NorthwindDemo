using Core.Application.Responses;

namespace Application.Features.UsStates.Commands.Create;

public class CreatedUsStateResponse : IResponse
{
    public Guid Id { get; set; }
    public string? StateName { get; set; }
    public string? StateAbbr { get; set; }
    public string? StateRegion { get; set; }
}