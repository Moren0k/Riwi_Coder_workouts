using System.Domain.DTOs;
using System.Domain.Models;

namespace System.Domain.Repositories;

public interface IOrderRepository
{
    //Obtenemos todos los pedidos
    //retorna una lista con las ordenes (utilizamos 'Task' porque sera asincrono)
    Task<IEnumerable<Order>> GetAllOrders();
    
    //obtenemos un pedido por ID
    //el parametro 'includeDetails' nos permite decidir si se cargar los detalles y el cliente asociado
    Task<Order?> GetOrderById(int id, bool includeDetails = true);
    
    //Obtenemos todos los pedidos de un cliente especifico
    Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
    
    //Agrega un pedido nuevo
    Task AddAsync(Order order);
    
    //Actualiza un pedido 
    Task Update(Order order);
    
    //Elimina un pedido
    Task Delete(Order order);
    
    //guardamos los cambios en la base de datos
    Task<int> SaveChangesAsync();
}