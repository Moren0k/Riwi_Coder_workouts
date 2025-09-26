namespace Veterinaria.Menus;

public class MenuAtenciones
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE ATENCIONES ===");
            Console.WriteLine("1. Registrar atención");
            Console.WriteLine("2. Listar atenciones");
            Console.WriteLine("3. Editar atención");
            Console.WriteLine("4. Eliminar atención");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarAtencion();
                    break;
                case "2":
                    ListarAtenciones();
                    break;
                case "3":
                    EditarAtencion();
                    break;
                case "4":
                    EliminarAtencion();
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

    private void RegistrarAtencion()
    {
    }

    private void ListarAtenciones()
    {
    }

    private void EditarAtencion()
    {
    }

    private void EliminarAtencion()
    {
    }
}