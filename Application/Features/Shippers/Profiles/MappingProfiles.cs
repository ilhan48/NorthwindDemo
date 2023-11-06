using Application.Features.Shippers.Commands.Create;
using Application.Features.Shippers.Commands.Delete;
using Application.Features.Shippers.Commands.Update;
using Application.Features.Shippers.Queries.GetById;
using Application.Features.Shippers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Shippers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shipper, CreateShipperCommand>().ReverseMap();
        CreateMap<Shipper, CreatedShipperResponse>().ReverseMap();
        CreateMap<Shipper, UpdateShipperCommand>().ReverseMap();
        CreateMap<Shipper, UpdatedShipperResponse>().ReverseMap();
        CreateMap<Shipper, DeleteShipperCommand>().ReverseMap();
        CreateMap<Shipper, DeletedShipperResponse>().ReverseMap();
        CreateMap<Shipper, GetByIdShipperResponse>().ReverseMap();
        CreateMap<Shipper, GetListShipperListItemDto>().ReverseMap();
        CreateMap<IPaginate<Shipper>, GetListResponse<GetListShipperListItemDto>>().ReverseMap();
    }
}