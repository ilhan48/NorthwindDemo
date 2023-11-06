using Application.Features.CustomerDemographics.Commands.Create;
using Application.Features.CustomerDemographics.Commands.Delete;
using Application.Features.CustomerDemographics.Commands.Update;
using Application.Features.CustomerDemographics.Queries.GetById;
using Application.Features.CustomerDemographics.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerDemographics.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerDemographic, CreateCustomerDemographicCommand>().ReverseMap();
        CreateMap<CustomerDemographic, CreatedCustomerDemographicResponse>().ReverseMap();
        CreateMap<CustomerDemographic, UpdateCustomerDemographicCommand>().ReverseMap();
        CreateMap<CustomerDemographic, UpdatedCustomerDemographicResponse>().ReverseMap();
        CreateMap<CustomerDemographic, DeleteCustomerDemographicCommand>().ReverseMap();
        CreateMap<CustomerDemographic, DeletedCustomerDemographicResponse>().ReverseMap();
        CreateMap<CustomerDemographic, GetByIdCustomerDemographicResponse>().ReverseMap();
        CreateMap<CustomerDemographic, GetListCustomerDemographicListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerDemographic>, GetListResponse<GetListCustomerDemographicListItemDto>>().ReverseMap();
    }
}