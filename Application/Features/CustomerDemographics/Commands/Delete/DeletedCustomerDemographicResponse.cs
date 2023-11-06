using Core.Application.Responses;

namespace Application.Features.CustomerDemographics.Commands.Delete;

public class DeletedCustomerDemographicResponse : IResponse
{
    public Guid Id { get; set; }
}