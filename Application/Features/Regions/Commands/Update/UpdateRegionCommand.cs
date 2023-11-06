using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Regions.Commands.Update;

public class UpdateRegionCommand : IRequest<UpdatedRegionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string RegionDescription { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRegions";

    public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, UpdatedRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public UpdateRegionCommandHandler(IMapper mapper, IRegionRepository regionRepository,
                                         RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<UpdatedRegionResponse> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            Region? region = await _regionRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _regionBusinessRules.RegionShouldExistWhenSelected(region);
            region = _mapper.Map(request, region);

            await _regionRepository.UpdateAsync(region!);

            UpdatedRegionResponse response = _mapper.Map<UpdatedRegionResponse>(region);
            return response;
        }
    }
}