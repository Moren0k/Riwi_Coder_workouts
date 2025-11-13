using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hu.Application.DTOs;
using Hu.Application.Interfaces;
using Hu.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hu.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> Authenticate(LoginUserDto userDto)
    {
        var user = await _userRepository.GetByEmailAsync(userDto.Email);
        
        if (user == null) throw new Exception("Email not found");
        
        bool passwordValid = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);

        if (passwordValid == false) throw new Exception("Password not found");
        
        // Genera Token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Id de token
            new Claim(JwtRegisteredClaimNames.Sub, user.Username), // Username
            new Claim(ClaimTypes.Role, user.Role.ToString()) // Rol
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        // Create Token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: cred
        );
        
        // Return token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}