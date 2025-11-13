using Hu.Domain.Entities;

namespace Hu.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task RemoveAsync(Product product);
    
    // Get
    Task<Product?> GetByIdAsync(int id);
    Task<Product?> GetByNameAsync(string name);
    Task<IEnumerable<Product>> GetAllAsync();
}