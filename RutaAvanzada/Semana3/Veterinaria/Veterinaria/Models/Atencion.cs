using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Atencion
{
    [Key] public int IdAtencion { get; private set; }
    public DateTime Fecha { get; private set; }
    public string Problema { get; private set; }
    public int MascotaId { get; private set; }
    public int VeterinarioId { get; private set; }
    
    /* Constructores */
    public Atencion() { }
    public Atencion(int idAtencion, DateTime fecha, string problema, int mascotaId,  int veterinarioId)
    {
        IdAtencion = idAtencion;
        Fecha = fecha;
        Problema = problema;
        MascotaId = mascotaId;
        VeterinarioId = veterinarioId;
    }
    
    /* Metodos */
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