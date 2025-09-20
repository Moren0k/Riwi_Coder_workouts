namespace RiwiMusic;
public static class Login
{
    public static void Menu()
    {   //Get userName, userPassword 
        Console.WriteLine("===== | Bienvenido a RiwiMusic | =====");
        Console.WriteLine("Ingrese el nombre del usuario: ");
        string? userName = Console.ReadLine();
        Console.WriteLine("Ingresa la contraseña del usuario:");
        string? userPassword = Console.ReadLine();
        
        VerifyLogin(userName, userPassword); //Send data to VerifyLogin
    }
    public static void VerifyLogin(string? userName, string? userPassword)
    {
        var user = DataStore.Users.FirstOrDefault(user => userName == user.UserName && userPassword == user.UserPassword);
        if (user!.UserStatus)
        {
            Console.WriteLine("Eres un Administrador");
            Admin.Menu();
        }
        else
        {
            Console.WriteLine("Eres un Cliente");
            Client.Menu();
        }
    }
}