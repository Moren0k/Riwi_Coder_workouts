using System.Runtime.InteropServices.JavaScript;

namespace RiwiMusic;
public class Admin
{
    public static void Menu()
    {
        int option = Convert.ToInt32(Console.ReadLine());
        do
        {
            Console.WriteLine("\n===== Menú Principal =====");
            Console.WriteLine("1. Gestión de Clientes");
            Console.WriteLine("2. Gestión de Conciertos");
            Console.WriteLine("3. Gestión de Tiquetes");
            Console.WriteLine("4. Consultas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            switch (option)
            {
                case 1:
                    Console.WriteLine("Gestión de Conciertos...");
                    break;
                case 2:
                    Console.WriteLine("Gestión de Clientes...");
                    break;
                case 3:
                    Console.WriteLine("Gestión de Tiquetes...");
                    break;
                case 4:
                    Console.WriteLine("Consultas...");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }
        } while (option == 0);
    }
}