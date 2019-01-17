using System;
using System.Threading;

namespace MyMessenger
{
    class LoginSignUP
    {
        internal static void Login()
        {
            Console.Clear();
            WelcomeScreen.WelcomeMethod();

            string LogedUser;

            InsertUsernamePassword(out LogedUser);

            if (DatabaseConnection.CheckUserRole(LogedUser) == "Admin")
            {
                var Menu = new Menus();
                while (Menu.AdminMenu(LogedUser))
                { }
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Mod")
            {
                var Menu = new Menus();
                while (Menu.ModMenu(LogedUser));
                { }
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Loyal")
            {
                var Menu = new Menus();
                while (Menu.LoyalMenu(LogedUser));
                { }
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Friend")
            {
                var Menu = new Menus();
                while(Menu.FriendMenu(LogedUser));
                { }
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Guest")
            {
                var Menu = new Menus();
                while(Menu.GuestMenu(LogedUser));
                { }
            }
        }

        internal static void SignUp()
        {
            Console.Clear();
            WelcomeScreen.WelcomeMethod();
            
            Console.WriteLine("Give me a username");

            string Name = Console.ReadLine();

            while (DatabaseConnection.CheckAvailableName(Name))
            {
                Console.WriteLine("Give me Another Username \nor Type (e) to Restart the App");
                Name = Console.ReadLine();
                if (Name == "e")
                {
                    Console.Clear();
                    return;
                }
            }
            DatabaseConnection.CreateUserDB(Name, Password.PasswordInsert());
        }

        internal static void InsertUsernamePassword(out string LogedUser)
        {
            Console.WriteLine("Give me your Username: ");
            string Username = Console.ReadLine();

            int TriesUser = 2;
            int TriesPass = 2;

            while (DatabaseConnection.CheckUserList(Username))
            {
                if (TriesUser >= 1)
                {
                    Console.WriteLine($"Remaining Tries: { TriesUser }");
                    TriesUser -= 1;
                    Username = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Application Will Close. Try Again Later...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Give me your Password: ");
            string LogPassword = Password.HidePassword();

            while (DatabaseConnection.checkForPassword(Username, LogPassword))
            {
                if (TriesPass >= 1)
                {
                    Console.WriteLine("Wrong Password. Try Again...");
                    Console.WriteLine($"Remaining Tries { TriesPass }");
                    TriesPass -= 1;
                    LogPassword = Password.HidePassword();
                }
                else
                {
                    Console.WriteLine("Application Will Close. Try Again Later...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
            LogedUser = Username;
        }
    }
}
