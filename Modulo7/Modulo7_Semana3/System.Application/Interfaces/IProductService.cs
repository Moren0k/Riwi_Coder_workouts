using System.Application.DTOs;

namespace System.Application.Interfaces;

public interface IProductService
{
    Task CreateAsync(ProductDto productDto);
    Task UpdateAsync(int id, ProductDto productDto);
    Task DeleteAsync(int id);

    // Get
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
}