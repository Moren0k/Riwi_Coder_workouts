using Hu.Application.DTOs;
using Hu.Domain.Entities;

namespace Hu.Application.Interfaces;

public interface IProductService
{
    Task AddProductAsync(AddProductDto productDto);
    Task UpdateProductAsync(int id,AddProductDto productDto);
    Task RemoveProductAsync(int id);
    
    Task<AddProductDto?> GetProductAsync(int id);
    Task<IEnumerable<AddProductDto>> GetAllProductsAsync();
}