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
        _dbContext = dbContext; // Db
    }

    public async Task<IEnumerable<Student>> GetAllAsync() // GetAll
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id) // GetById
    {
        return await _dbContext.Students.FindAsync(id);
    }
    
    public async Task AddAsync(Student student) // Add
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student) // Update
    {
        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student) // Delete
    {
        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
    }
}