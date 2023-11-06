using Application.Features.UsStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.UsStates.Commands.Create;

public class CreateUsStateCommand : IRequest<CreatedUsStateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? StateName { get; set; }
    public string? StateAbbr { get; set; }
    public string? StateRegion { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUsStates";

    public class CreateUsStateCommandHandler : IRequestHandler<CreateUsStateCommand, CreatedUsStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsStateRepository _usStateRepository;
        private readonly UsStateBusinessRules _usStateBusinessRules;

        public CreateUsStateCommandHandler(IMapper mapper, IUsStateRepository usStateRepository,
                                         UsStateBusinessRules usStateBusinessRules)
        {
            _mapper = mapper;
            _usStateRepository = usStateRepository;
            _usStateBusinessRules = usStateBusinessRules;
        }

        public async Task<CreatedUsStateResponse> Handle(CreateUsStateCommand request, CancellationToken cancellationToken)
        {
            UsState usState = _mapper.Map<UsState>(request);

            await _usStateRepository.AddAsync(usState);

            CreatedUsStateResponse response = _mapper.Map<CreatedUsStateResponse>(usState);
            return response;
        }
    }
}