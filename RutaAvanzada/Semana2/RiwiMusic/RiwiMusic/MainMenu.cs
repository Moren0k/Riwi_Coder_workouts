namespace RiwiMusic;

public static class MainMenu
{
    // User : UserName UserPassword UserStatus
    public static void Menu()
    {
        //Welcome and get user data
        Console.WriteLine("===== | Bienvenido a RiwiMusic | =====");
        Console.WriteLine("Ingrese el nombre del usuario:");
        string? userName = Console.ReadLine();
        Console.WriteLine("Ingresa la contraseña del usuario:");
        string? userPassword = Console.ReadLine();
        
        //Send data to VerifyLogin
        VerifyLogin(userName, userPassword);
    }

    public static void VerifyLogin(string? userName, string? userPassword)
    {
        foreach (var user in DataStore.Users)
        {
            if (userName == user.UserName && userPassword == user.UserPassword)
            {
                if (user.UserStatus == true)
                {
                    Console.WriteLine("Eres un Administrador");
                    Admin.Menu();//Menu for Admin <==
                }
                else if (user.UserStatus == false)
                {
                    Console.WriteLine("Eres un Cliente");
                    //logica de cliente
                    break;
                }
                else
                {
                    Console.WriteLine("El usuario no se encuentra registrado o datos incorrectos");
                    break;
                }
            }
        }
    }
}