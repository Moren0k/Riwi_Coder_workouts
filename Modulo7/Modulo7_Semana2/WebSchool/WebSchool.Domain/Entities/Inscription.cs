using System.ComponentModel.DataAnnotations;
using WebSchool.Domain.Enums;

namespace WebSchool.Domain.Entities;

public class Inscription
{
    [Key] public int Id { get; set; }
    [Required] public long StudentId { get; set; }
    [Required] public long CourseId { get; set; }
    [Required] public DateTime CreateAt { get; set; } = DateTime.Today;
    [Required] public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
}