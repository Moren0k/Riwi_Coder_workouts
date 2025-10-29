using Microsoft.AspNetCore.Mvc;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;

namespace WebSchool.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService; // ICourseService
    }

    [HttpGet]
    public async Task<IEnumerable<Course>> GetAllCourses() // Get All Courses
    {
        var courses = await _courseService.GetAllCourseAsync();
        return courses;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCoursesByIdAsync(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null) return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult> AddCourseAsync(Course course)
    {
        await _courseService.AddCourseAsync(course);
        return Ok($"Entity {course.Name} has been added with id {course.Id}.");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateCourseAsync(int id, Course course)
    {
        await _courseService.UpdateCourseAsync(id, course);
        return Ok($"Entity {id} has been updated.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourseAsync(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return Ok($"Entity {id} has been deleted.");
    }
}