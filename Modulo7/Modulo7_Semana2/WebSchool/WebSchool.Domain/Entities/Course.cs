using System.ComponentModel.DataAnnotations;

namespace WebSchool.Domain.Entities;

public class Course
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required, MaxLength(100)] public string Description { get; set; } = string.Empty;
    [Required] public int Capacity { get; set; } = 5;
}