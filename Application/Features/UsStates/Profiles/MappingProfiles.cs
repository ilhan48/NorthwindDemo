using Application.Features.UsStates.Commands.Create;
using Application.Features.UsStates.Commands.Delete;
using Application.Features.UsStates.Commands.Update;
using Application.Features.UsStates.Queries.GetById;
using Application.Features.UsStates.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UsStates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UsState, CreateUsStateCommand>().ReverseMap();
        CreateMap<UsState, CreatedUsStateResponse>().ReverseMap();
        CreateMap<UsState, UpdateUsStateCommand>().ReverseMap();
        CreateMap<UsState, UpdatedUsStateResponse>().ReverseMap();
        CreateMap<UsState, DeleteUsStateCommand>().ReverseMap();
        CreateMap<UsState, DeletedUsStateResponse>().ReverseMap();
        CreateMap<UsState, GetByIdUsStateResponse>().ReverseMap();
        CreateMap<UsState, GetListUsStateListItemDto>().ReverseMap();
        CreateMap<IPaginate<UsState>, GetListResponse<GetListUsStateListItemDto>>().ReverseMap();
    }
}