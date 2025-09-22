namespace RiwiMusic;
public static class User
{
    public static void Menu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Usuario =====");
            Console.WriteLine("1. Ver Conciertos");
            Console.WriteLine("2. Comprar Tickets");
            Console.WriteLine("0. Cerrar Sesion");
            
            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Ver Conciertos");
                    ShowConcerts();
                    break;
                case 2:
                    Console.WriteLine("Comprar Tickets");
                    BuyTicket();
                    break;
                case 0:
                    Console.WriteLine("Cerrar Sesion");
                    Login.Menu();
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        } while (menu);
    }
    private static void ShowConcerts()
    {
        Console.WriteLine("\n===== Lista de Conciertos =====");
        foreach (var concert in  DataStore.Concerts)
        {
            Console.WriteLine(@$"[{concert.ConcertId}] | Nombre: {concert.ConcertName}, Lugar: {concert.ConcertCity}
            Fecha: {concert.ConcertDate}, Precio: {concert.ConcertPrice} C/u");
        }
    }
    private static void BuyTicket()
    {
        //Logic buy tickets
        foreach (var concert in  DataStore.Concerts)
        {
            Console.WriteLine(@$"[{concert.ConcertId}] | Nombre: {concert.ConcertName}, Lugar: {concert.ConcertCity}
            Fecha: {concert.ConcertDate}, Precio: {concert.ConcertPrice} C/u");
        }
    }
}