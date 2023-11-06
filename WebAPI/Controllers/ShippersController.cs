using Application.Features.Shippers.Commands.Create;
using Application.Features.Shippers.Commands.Delete;
using Application.Features.Shippers.Commands.Update;
using Application.Features.Shippers.Queries.GetById;
using Application.Features.Shippers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShipperCommand createShipperCommand)
    {
        CreatedShipperResponse response = await Mediator.Send(createShipperCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShipperCommand updateShipperCommand)
    {
        UpdatedShipperResponse response = await Mediator.Send(updateShipperCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedShipperResponse response = await Mediator.Send(new DeleteShipperCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdShipperResponse response = await Mediator.Send(new GetByIdShipperQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShipperQuery getListShipperQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShipperListItemDto> response = await Mediator.Send(getListShipperQuery);
        return Ok(response);
    }
}