using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Infraestructure.Data;

namespace WebApi.Infraestructure.Repositories;

public class EfProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public EfProductRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _db.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _db.Products.ToListAsync();
        return products;
    }

    public async Task AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _db.Products.Update(product);
       await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
    
}
