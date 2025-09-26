namespace Veterinaria.Models;

public class Veterinario : Persona
{
    private int IdVeterinario { get; set; }
    private string Especialidad { get; set; }
    private int AniosExperiencia { get; set; }

    public Veterinario(int idVeterinario, string nombre, string apellido, int edad, string especialidad,
        int aniosExperiencia) : base(nombre, apellido, edad)
    {
        IdVeterinario = idVeterinario;
        Especialidad = especialidad;
        AniosExperiencia = aniosExperiencia;
    }

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