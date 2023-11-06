using Application.Features.UsStates.Commands.Create;
using Application.Features.UsStates.Commands.Delete;
using Application.Features.UsStates.Commands.Update;
using Application.Features.UsStates.Queries.GetById;
using Application.Features.UsStates.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsStatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUsStateCommand createUsStateCommand)
    {
        CreatedUsStateResponse response = await Mediator.Send(createUsStateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUsStateCommand updateUsStateCommand)
    {
        UpdatedUsStateResponse response = await Mediator.Send(updateUsStateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUsStateResponse response = await Mediator.Send(new DeleteUsStateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUsStateResponse response = await Mediator.Send(new GetByIdUsStateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUsStateQuery getListUsStateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUsStateListItemDto> response = await Mediator.Send(getListUsStateQuery);
        return Ok(response);
    }
}