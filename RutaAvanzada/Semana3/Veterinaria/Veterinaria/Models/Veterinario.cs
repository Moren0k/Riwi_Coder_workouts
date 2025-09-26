using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Veterinario : Persona //ClaseHija
{
    [Key] private int IdVeterinario { get; set; }
    [MaxLength(100)] private string? Especialidad { get; set; }
    private int AniosExperiencia { get; set; }

    protected Veterinario(int idVeterinario, string nombre, string apellido, int edad, string especialidad,
        int aniosExperiencia) : base(nombre, apellido, edad) //Constructor
    {
        IdVeterinario = idVeterinario;
        Especialidad = especialidad;
        AniosExperiencia = aniosExperiencia;
    }
}