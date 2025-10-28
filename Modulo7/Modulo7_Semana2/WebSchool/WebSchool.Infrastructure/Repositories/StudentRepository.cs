using Microsoft.EntityFrameworkCore;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infrastructure.Data;

namespace WebSchool.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;
    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await GetByIdAsync(id);
        _dbContext.Students.Remove(student!);
        await _dbContext.SaveChangesAsync();
    }
}