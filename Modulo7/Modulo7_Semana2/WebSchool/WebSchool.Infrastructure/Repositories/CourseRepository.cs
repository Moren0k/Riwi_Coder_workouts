using Microsoft.EntityFrameworkCore;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infrastructure.Data;

namespace WebSchool.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext; // Db
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _dbContext.Courses.FindAsync(id);
    }

    public async Task AddAsync(Course course)
    {
        _dbContext.Courses.Add(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        _dbContext.Courses.Update(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Course course)
    {
        _dbContext.Courses.Remove(course);
        await _dbContext.SaveChangesAsync();
    }
}