using Core.Application.Responses;

namespace Application.Features.CustomerDemographics.Commands.Create;

public class CreatedCustomerDemographicResponse : IResponse
{
    public Guid Id { get; set; }
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }
}