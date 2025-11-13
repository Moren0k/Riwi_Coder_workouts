using Hu.Domain.Entities;

namespace Hu.Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(User user);
    
    // Get
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
}