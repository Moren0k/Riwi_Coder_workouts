using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Atencion
{
    [Key] private int IdAtencion { get; set; }
    private DateTime Fecha { get; set; }
    [MaxLength(100)] private string Problema { get; set; }
    private int MascotaId { get; set; }
    private int VeterinarioId { get; set; }

    protected Atencion(int idAtencion, DateTime fecha, string problema, int mascotaId, int veterinarioId) //Constructor
    {
        IdAtencion = idAtencion;
        Fecha = fecha;
        Problema = problema;
        MascotaId = mascotaId;
        VeterinarioId = veterinarioId;
    }
}