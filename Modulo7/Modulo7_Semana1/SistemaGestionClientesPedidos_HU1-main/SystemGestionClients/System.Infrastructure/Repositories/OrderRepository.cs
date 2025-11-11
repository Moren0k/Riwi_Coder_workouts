using System.Domain.Models;
using System.Domain.Repositories;
using System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace System.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders
            .AsNoTracking()
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderById(int id, bool includeDetails = true)
    {
        IQueryable<Order> query = _context.Orders;

        if (includeDetails)
        {
            query = query
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer);
        }
        
        return await query
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
    {
        return await _context.Orders
            .AsNoTracking()
            .Include(o => o.CustomerId == customerId)
            .Include(o => o.OrderDetails)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}