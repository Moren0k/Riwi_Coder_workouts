using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services;

public class ClienteService : IPersona<Cliente>
{
    private readonly AppDbContext _db;
    public ClienteService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Cliente> Registrar(Cliente entity)
    {
        _db.Clientes.Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Cliente>> Listar()
    {
        return await _db.Clientes.ToListAsync();
    }

    public async Task<Cliente> Editar(Cliente entity)
    {
        _db.Clientes.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<Cliente> Eliminar(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();
        }
        return cliente!;
    }
}