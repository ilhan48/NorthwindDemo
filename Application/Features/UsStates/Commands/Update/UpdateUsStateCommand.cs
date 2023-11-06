using Application.Features.UsStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.UsStates.Commands.Update;

public class UpdateUsStateCommand : IRequest<UpdatedUsStateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? StateName { get; set; }
    public string? StateAbbr { get; set; }
    public string? StateRegion { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUsStates";

    public class UpdateUsStateCommandHandler : IRequestHandler<UpdateUsStateCommand, UpdatedUsStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsStateRepository _usStateRepository;
        private readonly UsStateBusinessRules _usStateBusinessRules;

        public UpdateUsStateCommandHandler(IMapper mapper, IUsStateRepository usStateRepository,
                                         UsStateBusinessRules usStateBusinessRules)
        {
            _mapper = mapper;
            _usStateRepository = usStateRepository;
            _usStateBusinessRules = usStateBusinessRules;
        }

        public async Task<UpdatedUsStateResponse> Handle(UpdateUsStateCommand request, CancellationToken cancellationToken)
        {
            UsState? usState = await _usStateRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _usStateBusinessRules.UsStateShouldExistWhenSelected(usState);
            usState = _mapper.Map(request, usState);

            await _usStateRepository.UpdateAsync(usState!);

            UpdatedUsStateResponse response = _mapper.Map<UpdatedUsStateResponse>(usState);
            return response;
        }
    }
}