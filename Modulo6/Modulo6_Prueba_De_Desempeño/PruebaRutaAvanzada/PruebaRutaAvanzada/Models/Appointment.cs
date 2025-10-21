using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaRutaAvanzada.Models;

public class Appointment
{
    [Key] public int Id { get; set; }
    
    [Required] public int PatientId { get; set; }
    
    [Required] public int DoctorId { get; set; }
    
    [Required] public DateTime Date { get; set; }
    [Required] public DateTime Time { get; set; }
    
    [MaxLength(200)] public string? Reason { get; set; }

    [Required,MaxLength(20)] public string? Status { get; set; } = "Scheduled";
    
    //Relaciones
    [ForeignKey(nameof(PatientId))] public Patient? Patient { get; set; }
    
    [ForeignKey(nameof(DoctorId))] public Doctor? Doctor { get; set; }
}