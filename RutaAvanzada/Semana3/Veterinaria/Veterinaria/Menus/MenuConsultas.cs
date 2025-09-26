namespace Veterinaria.Menus;

public class MenuConsultas
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAS ===");
            Console.WriteLine("1. Mascotas de Cliente");
            Console.WriteLine("2. Veterinario con Más Atenciones");
            Console.WriteLine("3. Especie Más Atendida");
            Console.WriteLine("4. Cliente con Más Mascotas");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MascotasDeCliente();
                    break;
                case "2":
                    VeterinarioMasAtenciones();
                    break;
                case "3":
                    EspecieMasAtendida();
                    break;
                case "4":
                    ClienteMasMascotas();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void MascotasDeCliente()
    {
    }

    private void VeterinarioMasAtenciones()
    {
    }

    private void EspecieMasAtendida()
    {
    }

    private void ClienteMasMascotas()
    {
    }
}