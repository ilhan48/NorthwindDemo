using Application.Features.Territories.Commands.Create;
using Application.Features.Territories.Commands.Delete;
using Application.Features.Territories.Commands.Update;
using Application.Features.Territories.Queries.GetById;
using Application.Features.Territories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TerritoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTerritoryCommand createTerritoryCommand)
    {
        CreatedTerritoryResponse response = await Mediator.Send(createTerritoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTerritoryCommand updateTerritoryCommand)
    {
        UpdatedTerritoryResponse response = await Mediator.Send(updateTerritoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTerritoryResponse response = await Mediator.Send(new DeleteTerritoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTerritoryResponse response = await Mediator.Send(new GetByIdTerritoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTerritoryQuery getListTerritoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTerritoryListItemDto> response = await Mediator.Send(getListTerritoryQuery);
        return Ok(response);
    }
}