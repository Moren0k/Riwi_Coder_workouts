using Veterinaria.Models;

namespace Veterinaria
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var cliente = new Cliente(1,"kevin","moreno",20,"319","k@gmail.com");
            var veterinario = new Veterinario(1, "andres", "david", 30, "c#", 10);
        }
    }
}