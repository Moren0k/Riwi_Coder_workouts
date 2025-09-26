using Veterinaria.Models;

namespace Veterinaria.Interfaces;

public interface IPersona<T> where T : Persona
{
    Task<T> RegistrarAsync(T entity); //Registrar
    Task<IEnumerable<T>> ListarAsync(); //Listar
    Task<T> EditarAsync(T entity); //Editar
    Task<T> EliminarAsync(int id); //Eliminar
}