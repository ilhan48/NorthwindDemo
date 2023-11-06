using Application.Features.CustomerDemographics.Commands.Create;
using Application.Features.CustomerDemographics.Commands.Delete;
using Application.Features.CustomerDemographics.Commands.Update;
using Application.Features.CustomerDemographics.Queries.GetById;
using Application.Features.CustomerDemographics.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerDemographicsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDemographicCommand createCustomerDemographicCommand)
    {
        CreatedCustomerDemographicResponse response = await Mediator.Send(createCustomerDemographicCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDemographicCommand updateCustomerDemographicCommand)
    {
        UpdatedCustomerDemographicResponse response = await Mediator.Send(updateCustomerDemographicCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCustomerDemographicResponse response = await Mediator.Send(new DeleteCustomerDemographicCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCustomerDemographicResponse response = await Mediator.Send(new GetByIdCustomerDemographicQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerDemographicQuery getListCustomerDemographicQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerDemographicListItemDto> response = await Mediator.Send(getListCustomerDemographicQuery);
        return Ok(response);
    }
}