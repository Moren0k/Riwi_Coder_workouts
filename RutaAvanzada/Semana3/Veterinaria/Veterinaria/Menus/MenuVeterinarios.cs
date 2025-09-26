namespace Veterinaria.Menus;

public class MenuVeterinarios
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE VETERINARIOS ===");
            Console.WriteLine("1. Registrar veterinario");
            Console.WriteLine("2. Listar veterinarios");
            Console.WriteLine("3. Editar veterinario");
            Console.WriteLine("4. Eliminar veterinario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarVeterinario();
                    break;
                case "2":
                    ListarVeterinarios();
                    break;
                case "3":
                    EditarVeterinario();
                    break;
                case "4":
                    EliminarVeterinario();
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

    private void RegistrarVeterinario()
    {
    }

    private void ListarVeterinarios()
    {
    }

    private void EditarVeterinario()
    {
    }

    private void EliminarVeterinario()
    {
    }
}