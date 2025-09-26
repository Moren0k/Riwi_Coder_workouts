using Veterinaria.Models;

namespace Veterinaria
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Menus.Menu menu = new Menus.Menu();
            menu.Mostrar();
        }
    }
}