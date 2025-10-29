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
        _studentService = studentService; // IStudentService
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> GetAllStudentsAsync() // Get All Students
    {
        var students = await _studentService.GetAllStudentsAsync();
        return students;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStudentByIdAsync(int id) // Get Student By ID
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudentAsync(Student student) // Add Student
    {
        await _studentService.AddStudentAsync(student);
        return Ok($"Entity {student.Name} has been added with ID {student.Id}");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateStudentAsync(int id, Student student) // Update Student
    {
        await _studentService.UpdateStudentAsync(id, student);
        return Ok($"Entity {id} has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentAsync(int id) // Delete Student
    {
        await _studentService.DeleteStudentAsync(id);
        return Ok($"Entity {id} has been deleted");
    }
}