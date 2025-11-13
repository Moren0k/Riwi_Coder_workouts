using Hu.Domain.Entities;
using Hu.Domain.Interfaces;
using Hu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hu.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(Product product)
    {
        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _appDbContext.Products.Update(product);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Product product)
    {
        _appDbContext.Products.Remove(product);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _appDbContext.Products.FindAsync(id);
    }

    public async Task<Product?> GetByNameAsync(string name)
    {
        return await _appDbContext.Products.SingleOrDefaultAsync(product => product.Name == name);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _appDbContext.Products.ToListAsync();
    }
}