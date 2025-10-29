using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infrastructure.Repositories;

namespace WebSchool.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<IEnumerable<Course>> GetAllCourseAsync()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        var courseEntity = await _courseRepository.GetByIdAsync(id);
        if (courseEntity == null) throw new Exception("Course not found");
        return courseEntity;
    }

    public async Task AddCourseAsync(Course course)
    {
        var courseEntity = await _courseRepository.GetByIdAsync(course.Id);
        if (courseEntity != null) throw new Exception("Course already exists");
        await _courseRepository.AddAsync(course);
    }

    public async Task UpdateCourseAsync(int id, Course course)
    {
        var courseEntity = await _courseRepository.GetByIdAsync(id);
        if (courseEntity == null) throw new Exception("Course not found");
        courseEntity.Name = course.Name;
        courseEntity.Description = course.Description;
        courseEntity.Capacity = course.Capacity;
        await _courseRepository.UpdateAsync(courseEntity);
    }
    
    public async Task DeleteCourseAsync(int id)
    {
        var courseEntity = await _courseRepository.GetByIdAsync(id);
        if (courseEntity == null) throw new Exception("Course not found");
        await _courseRepository.DeleteAsync(courseEntity);
    }
}