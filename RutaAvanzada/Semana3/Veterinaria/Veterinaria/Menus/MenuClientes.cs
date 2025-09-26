using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Menus;

public class MenuClientes
{
    private readonly ClienteService _clienteService;

    public MenuClientes()
    {
        _clienteService = new ClienteService(new AppDbContext());
    }

    public void Mostrar()
    {
        bool volver = false;

        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Editar cliente");
            Console.WriteLine("4. Eliminar cliente");
            
            Console.WriteLine("3. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarCliente();
                    break;
                case "2":
                    //ListarClientes();
                    break;
                case "3":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void RegistrarCliente()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine()!;

        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine()!);

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine()!;

        Console.Write("Correo electrónico: ");
        string correo = Console.ReadLine()!;

        var cliente = new Cliente(id, nombre, apellido, edad, telefono, correo);
        cliente.Registrar();

        Console.WriteLine("Cliente registrado correctamente.");
    }
    
    private void ListarClientes(){}
    private void EditarCliente(){}
    private void EliminarCliente(){}
}
