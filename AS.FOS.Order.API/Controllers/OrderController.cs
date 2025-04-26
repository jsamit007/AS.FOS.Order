using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Queries;
using AS.FOS.Order.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AS.FOS.Order.API.Controllers;

[ApiController]
[Route("api/v1/order")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateOrderResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrderById), new { OrderId = order.OrderId }, order);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TrackOrderResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var order = await _mediator.Send(new TrackOrderQuery(new Domain.ValueObjects.OrderId(orderId)));
        return Ok(order);
    }
}
