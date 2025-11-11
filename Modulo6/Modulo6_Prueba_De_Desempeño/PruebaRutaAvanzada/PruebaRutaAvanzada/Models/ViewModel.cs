namespace PruebaRutaAvanzada.Models;

public class ViewModel
{
    public List<Patient> Patients { get; set; } = new();
    public List<Doctor> Doctors { get; set; } = new();
    public List<Appointment> Appointments { get; set; } = new();
}