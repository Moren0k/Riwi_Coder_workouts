using Hu.Application.DTOs;
using Hu.Application.Interfaces;
using Hu.Domain.Entities;
using Hu.Domain.Interfaces;

namespace Hu.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public UserService(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository; // Repository
        _authService = authService;
    }

    public async Task RegisterUserAsync(RegisterUserDto userDto)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

        var registerUser = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            Password = hashedPassword,
            Role = userDto.Role
        };

        await _userRepository.AddAsync(registerUser);
    }

    public async Task<string?> LoginUserAsync(LoginUserDto userDto)
    {
        return await _authService.Authenticate(userDto);
    }

    public async Task UpdateUserAsync(int id, RegisterUserDto userDto)
    {
        var updateUser = await _userRepository.GetByIdAsync(id);

        if (updateUser == null) throw new Exception("User not found");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

        updateUser.Username = userDto.Username;
        updateUser.Email = userDto.Email;
        updateUser.Password = hashedPassword;
        updateUser.Role = userDto.Role;

        await _userRepository.UpdateAsync(updateUser);
    }

    public async Task RemoveUserAsync(int id)
    {
        var removeUser = await _userRepository.GetByIdAsync(id);

        if (removeUser == null) throw new Exception("User not found");

        await _userRepository.RemoveAsync(removeUser);
    }

    public async Task<UserDto?> GetUserAsync(int id)
    {
        var getUser = await _userRepository.GetByIdAsync(id);

        if (getUser == null) throw new Exception("User not found");

        var user = new UserDto
        {
            Username = getUser.Username,
            Email = getUser.Email,
            Role = getUser.Role
        };

        return user;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var getUsers = await _userRepository.GetAllAsync();

        return getUsers.Select(user => new UserDto
        {
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        });
    }
}