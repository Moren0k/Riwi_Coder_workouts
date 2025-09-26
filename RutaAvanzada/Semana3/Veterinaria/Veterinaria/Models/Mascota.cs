namespace Veterinaria.Models;

public class Mascota
{
    private int IdMascota { get; set; }
    private string Nombre { get; set; }
    private string Especie { get; set; }
    private int Edad { get; set; }

    public Mascota(int idMascota, string nombre, string especie, int edad)
    {
        IdMascota = idMascota;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }
    
    public void Registrar()
    {
        /* implementación común */
    }

    public void Listar()
    {
        /* implementación común */
    }

    public void Editar()
    {
        /* implementación común */
    }

    public void Eliminar()
    {
        /* implementación común */
    }
}