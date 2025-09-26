using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Menus;

public class MenuClientes
{
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
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    EditarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "0":
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

    private async Task RegistrarCliente()
    {
        using var context = new AppDbContext();
        var service = new ClienteService(context);

        Console.Clear();
        Console.WriteLine("=== REGISTRAR CLIENTE ===");
        Console.Write("ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Telefono: ");
        string telefono = Console.ReadLine();
        Console.Write("Correo Electronico: ");
        string correoElectronico = Console.ReadLine();

        var cliente = new Cliente(id, nombre, apellido, edad, telefono, correoElectronico);
        await service.Registrar(cliente);
        Console.WriteLine("Cliente registrado correctamente");
    }
    
    private async Task ListarClientes()
    {
        using var context = new AppDbContext();
        var service = new ClienteService(context);

        var clientes = await service.Listar();
        Console.WriteLine("=== LISTA DE CLIENTES ===");
        foreach (var c in clientes)
        {
            Console.WriteLine($"{c.IdCliente} - {c.Nombre} {c.Apellido} ({c.Edad})");
        }
    }


    private async Task EditarCliente()
    {
        using var context = new AppDbContext();
        var service = new ClienteService(context);

        Console.Clear();
        Console.WriteLine("=== EDITAR CLIENTE ===");

        Console.Write("Ingrese el ID del cliente a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        // buscar cliente existente
        var cliente = await context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }
        
        Console.Write("Nuevo Nombre : ");
        string? nombre = Console.ReadLine();
        Console.Write("Nuevo Apellido : ");
        string? apellido = Console.ReadLine();
        Console.Write("Nueva Edad : ");
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nuevo Teléfono : ");
        string? telefono = Console.ReadLine();
        Console.Write("Nuevo Correo Electrónico : ");
        string? correo = Console.ReadLine();
        
        cliente.Nombre = nombre;
        cliente.Apellido = apellido;
        cliente.Edad = edad;
        cliente.Telefono = telefono;
        cliente.CorreoElectronico = correo;

        await service.Editar(cliente);
        Console.WriteLine("Cliente editado correctamente");
    }


    private async Task EliminarCliente()
    {
        using var context = new AppDbContext();
        var service = new ClienteService(context);

        Console.Clear();
        Console.WriteLine("=== ELIMINAR CLIENTE ===");

        Console.Write("Ingrese el ID del cliente a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var cliente = await context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }
        await service.Eliminar(id);
        Console.WriteLine("Cliente eliminado correctamente.");
    }

}