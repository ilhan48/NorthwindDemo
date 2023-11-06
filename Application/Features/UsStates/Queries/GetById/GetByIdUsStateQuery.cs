using Application.Features.UsStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UsStates.Queries.GetById;

public class GetByIdUsStateQuery : IRequest<GetByIdUsStateResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUsStateQueryHandler : IRequestHandler<GetByIdUsStateQuery, GetByIdUsStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsStateRepository _usStateRepository;
        private readonly UsStateBusinessRules _usStateBusinessRules;

        public GetByIdUsStateQueryHandler(IMapper mapper, IUsStateRepository usStateRepository, UsStateBusinessRules usStateBusinessRules)
        {
            _mapper = mapper;
            _usStateRepository = usStateRepository;
            _usStateBusinessRules = usStateBusinessRules;
        }

        public async Task<GetByIdUsStateResponse> Handle(GetByIdUsStateQuery request, CancellationToken cancellationToken)
        {
            UsState? usState = await _usStateRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _usStateBusinessRules.UsStateShouldExistWhenSelected(usState);

            GetByIdUsStateResponse response = _mapper.Map<GetByIdUsStateResponse>(usState);
            return response;
        }
    }
}