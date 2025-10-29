using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCourseAsync(); // GetAllStudent
    Task<Course?> GetCourseByIdAsync(int id); // GetByIdStudent
    Task AddCourseAsync(Course course); // AddStudent
    Task UpdateCourseAsync(int id, Course course); // UpdateStudent
    Task DeleteCourseAsync(int id); // DeleteStudent
}