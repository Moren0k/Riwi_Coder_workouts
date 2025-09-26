namespace Veterinaria.Menus;

public class Menu
{
    public void Mostrar()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Gestion Clientes");
            Console.WriteLine("2. Gestion Veterinarios");
            Console.WriteLine("3. Gestion Mascotas");
            Console.WriteLine("4. Gestion Atenciones");
            Console.WriteLine("5. Consultas Avanzadas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ejecutando GestionClientes...");
                    GestionClientes();
                    break;
                case "2":
                    Console.WriteLine("Ejecutando GestionVeterinarios...");
                    GestionVeterinarios();
                    break;
                case "3":
                    Console.WriteLine("Ejecutando GestionMascotas...");
                    GestionMascotas();
                    break;
                case "4":
                    Console.WriteLine("Ejecutando GestionAtenciones...");
                    GestionAtenciones();
                    break;
                case "5":
                    Console.WriteLine("Ejecutando ConsultasAvanzadas...");
                    ConsultasAvanzadas();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa Veterinaria...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void GestionClientes()
    {
        MenuClientes clientes = new MenuClientes();
        clientes.Mostrar();
    }

    private void GestionVeterinarios()
    {
        //Kevin
    }

    private void GestionMascotas()
    {
        //Mariana
    }

    private void GestionAtenciones()
    {
        //Santos
    }

    private void ConsultasAvanzadas()
    {
    }
}