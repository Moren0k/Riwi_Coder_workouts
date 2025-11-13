using Hu.Domain.Entities;
using Hu.Domain.Interfaces;
using Hu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hu.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext; // Db
    }

    public async Task AddAsync(User user)
    {
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(User user)
    {
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
    }

    // Get
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _appDbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _appDbContext.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _appDbContext.Users.ToListAsync();
    }
}