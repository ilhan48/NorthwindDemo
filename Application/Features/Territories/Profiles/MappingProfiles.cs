using Application.Features.Territories.Commands.Create;
using Application.Features.Territories.Commands.Delete;
using Application.Features.Territories.Commands.Update;
using Application.Features.Territories.Queries.GetById;
using Application.Features.Territories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Territories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Territory, CreateTerritoryCommand>().ReverseMap();
        CreateMap<Territory, CreatedTerritoryResponse>().ReverseMap();
        CreateMap<Territory, UpdateTerritoryCommand>().ReverseMap();
        CreateMap<Territory, UpdatedTerritoryResponse>().ReverseMap();
        CreateMap<Territory, DeleteTerritoryCommand>().ReverseMap();
        CreateMap<Territory, DeletedTerritoryResponse>().ReverseMap();
        CreateMap<Territory, GetByIdTerritoryResponse>().ReverseMap();
        CreateMap<Territory, GetListTerritoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<Territory>, GetListResponse<GetListTerritoryListItemDto>>().ReverseMap();
    }
}