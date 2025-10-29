using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository; // IStudentRepository
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync() // GetAllStudent
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id) // GetByIdStudent
    {
        var studentEntity = await _studentRepository.GetByIdAsync(id);
        if (studentEntity == null) throw new Exception("Student not found");
        return studentEntity;
    }

    public async Task AddStudentAsync(Student student) // AddStudent
    {
        var studentEntity = await _studentRepository.GetByIdAsync(student.Id);
        if (studentEntity != null) throw new Exception("Student already exists");
        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(int id, Student student) // UpdateStudent
    {
        var studentEntity = await _studentRepository.GetByIdAsync(id);
        if (studentEntity == null) throw new Exception("Student not found");
        studentEntity.Name = student.Name;
        studentEntity.LastName = student.LastName;
        studentEntity.Dni = student.Dni;
        await _studentRepository.UpdateAsync(studentEntity);
    }

    public async Task DeleteStudentAsync(int id) // DeleteStudent
    {
        var studentEntity = await _studentRepository.GetByIdAsync(id);
        if (studentEntity == null) throw new Exception("Student not found");
        await _studentRepository.DeleteAsync(studentEntity);
    }
}