namespace Veterinaria.Menus;

public class MenuMascotas
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE MASCOTAS ===");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Listar mascotas");
            Console.WriteLine("3. Editar mascota");
            Console.WriteLine("4. Eliminar mascota");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarMascota();
                    break;
                case "2":
                    ListarMascotas();
                    break;
                case "3":
                    EditarMascota();
                    break;
                case "4":
                    EliminarMascota();
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

    private void RegistrarMascota()
    {
    }

    private void ListarMascotas()
    {
    }

    private void EditarMascota()
    {
    }

    private void EliminarMascota()
    {
    }
}