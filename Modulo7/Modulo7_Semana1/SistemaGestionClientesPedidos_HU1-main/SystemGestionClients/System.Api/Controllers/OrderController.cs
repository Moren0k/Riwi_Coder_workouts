using System.Application.Interfaces;
using System.Domain.DTOs;
using System.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace System.Api.Controllers;

[ApiController] //habilita validacion automatica y comportamiento REST
[Route("api/order")] //ruta base: api/order
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
            return NotFound("Order not found");
        
        return Ok(order);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetByCustomer(int customerId)
    {
        var orders = await _orderService.GetByCustomerIdAsync(customerId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> Create([FromBody] OrderDto order)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Order orderEntity = new Order
        {
            CustomerId = order.customerId,
            OrderDate = order.OrderDate,
            Status = order.Status
        };
        
        var createdOrder = await _orderService.CreateAsync(orderEntity);
        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderDto>> Update(int id, [FromBody] Order order)
    {
        if (id != order.Id)
            return BadRequest("The ID entered does not exist");

        try
        {
            await _orderService.UpdateAsync(order);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}