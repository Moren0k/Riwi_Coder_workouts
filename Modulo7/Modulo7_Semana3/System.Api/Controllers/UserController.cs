using System.Application.DTOs;
using System.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace System.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost("auth/register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        await _service.RegisterAsync(request);
        return Ok("Usuario registrado");
    }
    
    [HttpPost("auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _service.LoginAsync(request);
        if (token == null)
            return Unauthorized("Credenciales inválidas");

        return Ok(new { token });
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    
    [HttpGet("by-username/{username}")]
    [Authorize]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var user = await _service.GetByUsernameAsync(username);
        if (user == null) return NotFound();
        return Ok(user);
    }
    
    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUser request)
    {
        await _service.UpdateAsync(id, request);
        return Ok("Usuario actualizado");
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Usuario eliminado");
    }
}