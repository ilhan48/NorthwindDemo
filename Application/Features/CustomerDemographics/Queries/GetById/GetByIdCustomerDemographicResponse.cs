using Core.Application.Responses;

namespace Application.Features.CustomerDemographics.Queries.GetById;

public class GetByIdCustomerDemographicResponse : IResponse
{
    public Guid Id { get; set; }
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }
}