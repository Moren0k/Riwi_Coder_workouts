using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(); // GetAllStudent
    Task<Student?> GetStudentByIdAsync(int id); // GetByIdStudent
    Task AddStudentAsync(Student student); // AddStudent
    Task UpdateStudentAsync(int id, Student student); // UpdateStudent
    Task DeleteStudentAsync(int id); // DeleteStudent
}