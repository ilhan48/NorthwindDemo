using Application.Features.UsStates.Constants;
using Application.Features.UsStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.UsStates.Commands.Delete;

public class DeleteUsStateCommand : IRequest<DeletedUsStateResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUsStates";

    public class DeleteUsStateCommandHandler : IRequestHandler<DeleteUsStateCommand, DeletedUsStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsStateRepository _usStateRepository;
        private readonly UsStateBusinessRules _usStateBusinessRules;

        public DeleteUsStateCommandHandler(IMapper mapper, IUsStateRepository usStateRepository,
                                         UsStateBusinessRules usStateBusinessRules)
        {
            _mapper = mapper;
            _usStateRepository = usStateRepository;
            _usStateBusinessRules = usStateBusinessRules;
        }

        public async Task<DeletedUsStateResponse> Handle(DeleteUsStateCommand request, CancellationToken cancellationToken)
        {
            UsState? usState = await _usStateRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _usStateBusinessRules.UsStateShouldExistWhenSelected(usState);

            await _usStateRepository.DeleteAsync(usState!);

            DeletedUsStateResponse response = _mapper.Map<DeletedUsStateResponse>(usState);
            return response;
        }
    }
}