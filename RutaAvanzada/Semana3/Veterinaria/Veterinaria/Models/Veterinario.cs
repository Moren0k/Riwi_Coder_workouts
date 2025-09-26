using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Veterinario : Persona
{
    [Key] public int IdVeterinario { get; set; }
    [MaxLength(100)] public string? Especialidad { get; private set; }
    public int AniosExperiencia { get; private set; }
    
    /* Constructores */
    public Veterinario() { }
    public Veterinario(int idVeterinario, string nombre, string apellido, int edad, string especialidad,
        int aniosExperiencia) : base(nombre, apellido, edad)
    {
        IdVeterinario = idVeterinario;
        Especialidad = especialidad;
        AniosExperiencia = aniosExperiencia;
    }
    
    /* Metodos */
    public override void Registrar()
    {
        /* implementación */
    }

    public override void Listar()
    {
        /* implementación */
    }

    public override void Editar()
    {
        /* implementación */
    }

    public override void Eliminar()
    {
        /* implementación */
    }
}