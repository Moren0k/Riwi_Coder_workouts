using System.Data;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return students;
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return student;
    }

    public async Task AddStudentAsync(Student student)
    {
        var checkStudent = await _studentRepository.GetByIdAsync(student.Id);
        if (checkStudent != null) throw new Exception("Student already exists");
        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var checkStudent = await _studentRepository.GetByIdAsync(student.Id);
        if (checkStudent == null) throw new Exception("Student not found");
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        var checkStudent = await _studentRepository.GetByIdAsync(id);
        if (checkStudent == null) throw new Exception("Student not found");
        await _studentRepository.DeleteAsync(id);
    }
}