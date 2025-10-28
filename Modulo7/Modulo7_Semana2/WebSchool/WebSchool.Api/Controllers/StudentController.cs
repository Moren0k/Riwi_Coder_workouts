using Microsoft.AspNetCore.Mvc;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;

namespace WebSchool.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _studentService.GetAllStudentsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
    {
        return (await _studentService.GetStudentByIdAsync(id))!;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] Student student)
    {
        await _studentService.AddStudentAsync(student);
        return CreatedAtAction(nameof(GetStudentByIdAsync), new { id = student.Id }, student);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateStudentAsync([FromBody] Student student)
    {
        await _studentService.UpdateStudentAsync(student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentAsync([FromBody] int id)
    {
        await _studentService.DeleteStudentAsync(id);
        return Ok();
    }
}