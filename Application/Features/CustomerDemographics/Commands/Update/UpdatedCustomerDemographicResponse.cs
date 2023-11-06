using Core.Application.Responses;

namespace Application.Features.CustomerDemographics.Commands.Update;

public class UpdatedCustomerDemographicResponse : IResponse
{
    public Guid Id { get; set; }
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }
}