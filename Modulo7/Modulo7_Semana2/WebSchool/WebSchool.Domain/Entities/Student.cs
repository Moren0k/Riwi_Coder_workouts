using System.ComponentModel.DataAnnotations;

namespace WebSchool.Domain.Entities;

public class Student
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required, MaxLength(100)] public string LastName { get; set; } = string.Empty;
    [Required] public string Dni { get; set; } = string.Empty;
}