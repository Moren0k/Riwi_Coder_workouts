using System.Application.DTOs;

namespace System.Application.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterRequest request); // Register
    Task<string?> LoginAsync(LoginRequest request); // Login

    Task UpdateAsync(int id, UpdateUser updateUser);
    Task DeleteAsync(int id);

    // Get
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto?> GetByUsernameAsync(string username);
}