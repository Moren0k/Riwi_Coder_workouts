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
}