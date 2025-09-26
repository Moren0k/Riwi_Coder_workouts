namespace Veterinaria.Models;

public class Atencion
{
    private int IdAtencion { get; set; }
    private DateTime Fecha { get; set; }
    private string Problema { get; set; }
    private int MascotaId { get; set; }
    private int VeterinarioId { get; set; }

    public Atencion(int idAtencion, DateTime fecha, string problema, int mascotaId,  int veterinarioId)
    {
        IdAtencion = idAtencion;
        Fecha = fecha;
        Problema = problema;
        MascotaId = mascotaId;
        VeterinarioId = veterinarioId;
    }
}