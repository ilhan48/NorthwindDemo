using Core.Application.Responses;

namespace Application.Features.UsStates.Commands.Delete;

public class DeletedUsStateResponse : IResponse
{
    public Guid Id { get; set; }
}