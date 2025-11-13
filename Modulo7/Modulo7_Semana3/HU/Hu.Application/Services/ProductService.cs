using Hu.Application.DTOs;
using Hu.Application.Interfaces;
using Hu.Domain.Entities;
using Hu.Domain.Interfaces;

namespace Hu.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(AddProductDto productDto)
    {
        var addProduct = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock,
        };

        await _productRepository.AddAsync(addProduct);
    }

    public async Task UpdateProductAsync(int id, AddProductDto productDto)
    {
        var updateProduct = await _productRepository.GetByIdAsync(id);

        if (updateProduct == null) throw new Exception("Product not found");

        updateProduct.Name = productDto.Name;
        updateProduct.Price = productDto.Price;
        updateProduct.Stock = productDto.Stock;

        await _productRepository.UpdateAsync(updateProduct);
    }

    public async Task RemoveProductAsync(int id)
    {
        var removeProduct = await _productRepository.GetByIdAsync(id);

        if (removeProduct == null) throw new Exception("Product not found");

        await _productRepository.RemoveAsync(removeProduct);
    }

    public async Task<AddProductDto?> GetProductAsync(int id)
    {
        var getProduct = await _productRepository.GetByIdAsync(id);

        if (getProduct == null) throw new Exception("Product not found");

        var product = new AddProductDto
        {
            Name = getProduct.Name,
            Price = getProduct.Price,
            Stock = getProduct.Stock,
        };

        return product;
    }

    public async Task<IEnumerable<AddProductDto>> GetAllProductsAsync()
    {
        var getProducts = await _productRepository.GetAllAsync();

        return getProducts.Select(product => new AddProductDto
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        });
    }
}