using Core.Application.Dtos;

namespace Application.Features.CustomerDemographics.Queries.GetList;

public class GetListCustomerDemographicListItemDto : IDto
{
    public Guid Id { get; set; }
    public string CustomerTypeId { get; set; }
    public string? CustomerDesc { get; set; }
}