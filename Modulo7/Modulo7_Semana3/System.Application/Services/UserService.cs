using System.Application.DTOs;
using System.Application.Interfaces;
using System.Domain.Entities;
using System.Domain.Interfaces;

namespace System.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository; // User Repository
    private readonly IAuthService _authService; // Auth Service

    public UserService(IUserRepository repository, IAuthService authService)
    {
        _userRepository = repository;
        _authService = authService;
    }

    public async Task RegisterAsync(RegisterRequest request) // Register
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = hash,
            Role = request.Role?.ToLower() == "admin"
                ? Role.Admin
                : (request.Role?.ToLower() == "user" ? Role.User : Role.Guest)
        };

        await _userRepository.AddAsync(user);
    }

    public async Task<string?> LoginAsync(LoginRequest request) // Login
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null) return null;

        return await _authService.Authenticate(user.Email, request.Password);
    }

    public async Task UpdateAsync(int id, UpdateUser? updateUser)
    {
        if (updateUser == null) return;

        var u = await _userRepository.GetByIdAsync(id);

        if (u != null)
        {
            u.Username = updateUser.Username;
            u.Email = updateUser.Email;
            u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUser.Password);
            u.Role = updateUser.Role.ToLower() == "admin"
                ? Role.Admin
                : (updateUser.Role.ToLower() == "user" ? Role.User : Role.Guest);
            await _userRepository.UpdateAsync(u);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user != null) await _userRepository.DeleteAsync(user);
    }

    // Get
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(u => new UserDto
        {
            Username = u.Username,
            Email = u.Email,
            Role = u.Role.ToString()
        });
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var u = await _userRepository.GetByIdAsync(id);

        if (u == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var user = new UserDto
        {
            Username = u.Username,
            Email = u.Email,
            Role = u.Role.ToString()
        };

        return user;
    }

    public async Task<UserDto?> GetByUsernameAsync(string username)
    {
        var u = await _userRepository.GetByUsernameAsync(username);

        if (u == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var user = new UserDto
        {
            Username = u.Username,
            Email = u.Email,
            Role = u.Role.ToString()
        };

        return user;
    }
}