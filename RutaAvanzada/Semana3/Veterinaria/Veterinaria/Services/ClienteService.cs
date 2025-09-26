using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class ClienteService
{
    private readonly AppDbContext _db;

    public ClienteService(AppDbContext context)
    {
        _db = context;
    }

    public void RegistrarCliente(int idCliente, string nombre, string apellido, int edad, string telefono,
        string correoElectronico)
    {
        var nuevoCliente = new Cliente(idCliente, nombre, apellido, edad, telefono, correoElectronico);
        _db.Clientes.Add(nuevoCliente);
        _db.SaveChanges();
    }
}