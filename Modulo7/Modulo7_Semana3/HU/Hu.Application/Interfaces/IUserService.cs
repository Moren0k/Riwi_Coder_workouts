using Hu.Application.DTOs;

namespace Hu.Application.Interfaces;

public interface IUserService
{
    Task RegisterUserAsync(RegisterUserDto userDto); // Register
    Task<String?> LoginUserAsync(LoginUserDto userDto); // Login
    
    Task UpdateUserAsync(int id,RegisterUserDto userDto); // Update
    Task RemoveUserAsync(int id); // Remove
    
    Task<UserDto?> GetUserAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(); // GetAll
}