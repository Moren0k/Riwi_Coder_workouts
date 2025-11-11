using System.Application.DTOs;
using System.Application.Interfaces;
using System.Domain.Entities;
using System.Domain.Interfaces;

namespace System.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository; // Product Repository

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task CreateAsync(ProductDto productDto)
    {
        if (productDto == null)
        {
            throw new ArgumentNullException(nameof(productDto));
        }

        var newProduct = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description!,
            Price = productDto.Price,
            Stock = productDto.Stock
        };

        await _productRepository.AddAsync(newProduct);
    }

    public async Task UpdateAsync(int id, ProductDto productDto)
    {
        var p = await _productRepository.GetByIdAsync(id);

        if (p != null)
        {
            p.Name = productDto.Name;
            p.Description = productDto.Description!;
            p.Price = productDto.Price;
            p.Stock = productDto.Stock;

            await _productRepository.UpdateAsync(p);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var p = await _productRepository.GetByIdAsync(id);
        if (p != null) await _productRepository.DeleteAsync(p);
    }

    // Get
    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock
        });
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var p = await _productRepository.GetByIdAsync(id);

        if (p == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        var product = new ProductDto
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock
        };

        return product;
    }
}