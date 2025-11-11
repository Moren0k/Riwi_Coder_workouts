using System.Application.Interfaces;
using System.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace System.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    public AuthService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration; // Para traer de AppSettings
        _userRepository = userRepository; // User Repository
    }
    
    public async Task<string?> Authenticate(string email, string password)
    {
        // Obtener usuario por el Email
        var user = await _userRepository.GetByEmailAsync(email);
        
        // Validar contraseña
        bool passwordValid = BCrypt.Net.BCrypt.Verify(password, user!.PasswordHash);

        if (passwordValid == false) throw new Exception("Password is incorrect"); 
        
        // Generar token claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
        // Create Token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: cred
        );
    
        // Retornar el token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}