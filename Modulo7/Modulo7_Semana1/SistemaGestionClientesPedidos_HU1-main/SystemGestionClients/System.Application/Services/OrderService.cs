using System.Application.Interfaces;
using System.Domain.DTOs;
using System.Domain.Models;
using System.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace System.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    //obtener todos las ordenes
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllOrders();
    }
    
    //obtener un orden por ID
    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _orderRepository.GetOrderById(id);
    }

    //obtener ordenes de un cliente
    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId)
    {
        return await _orderRepository.GetOrdersByCustomerId(customerId);
    }

    //creae una orden
    public async Task<Order> CreateAsync(Order order)
    {
        
        
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();
        return order;
    }

    //actualizar una orden
    public async Task UpdateAsync(Order order)
    {
        var existingOrder = await _orderRepository.GetOrderById(order.Id);
        if (existingOrder == null)
            throw new Exception("The order to update was not found");
        
        //actualiza los datos
        _orderRepository.Update(order);
        await _orderRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepository.GetOrderById(id);
        if (order == null)
            throw new Exception("The order you want to delete does not exist");
        
        _orderRepository.Delete(order);
        await _orderRepository.SaveChangesAsync();
    }
}