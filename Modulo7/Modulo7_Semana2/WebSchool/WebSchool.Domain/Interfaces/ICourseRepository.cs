using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync(); // GetAll
    Task<Course?> GetByIdAsync(int id); // GetById
    Task AddAsync(Course course); // Add
    Task UpdateAsync(Course course); // Update
    Task DeleteAsync(Course course); // Delete
}