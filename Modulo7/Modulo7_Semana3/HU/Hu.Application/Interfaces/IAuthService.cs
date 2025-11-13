using Hu.Application.DTOs;

namespace Hu.Application.Interfaces;

public interface IAuthService
{
    public Task<String> Authenticate(LoginUserDto userDto);
}