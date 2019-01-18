using System;
using System.Threading;

namespace MyMessenger
{
    class LoginSignUP
    {
        internal static void Login()
        {
            Console.Clear();
            Design.WelcomeMethod();

            string logedUser;
            InsertUsernamePassword(out logedUser);

            var menu = new Menus();
            while (menu.GeneralMenu(logedUser))
            { }
        }

        internal static void RoleMenu(string logedUser)
        {

            if (DatabaseConnection.CheckUserRole(logedUser) == "Admin")
            {
                var menu = new Menus();
                while (menu.AdminActionsMenu(logedUser))
                { }
            }
            else if (DatabaseConnection.CheckUserRole(logedUser) == "Mod")
            {
                var menu = new Menus();
                while (menu.ModActionsMenu(logedUser)) ;
                { }
            }
            else if (DatabaseConnection.CheckUserRole(logedUser) == "Loyal")
            {
                var menu = new Menus();
                while (menu.LoyalActionsMenu(logedUser)) ;
                { }
            }
            else if (DatabaseConnection.CheckUserRole(logedUser) == "Friend")
            {
                var menu = new Menus();
                while (menu.FriendActionsMenu(logedUser)) ;
                { }
            }
            else if (DatabaseConnection.CheckUserRole(logedUser) == "Guest")
            {
                Console.WriteLine("Your Role is Guest ... You dont have any Role Action's");

                Design.ConsoleClear();
            }
        }

        internal static void SignUp()
        {
            Console.Clear();
            Design.WelcomeMethod();
            
            Console.WriteLine("Give me a username");

            string name = Console.ReadLine();

            while (DatabaseConnection.CheckAvailableName(name))
            {
                Console.WriteLine("Give me Another Username \nor Type (e) to Restart the App");
                name = Console.ReadLine();
                if (name == "e")
                {
                    Console.Clear();
                    return;
                }
            }
            DatabaseConnection.CreateUserDB(name, Password.PasswordInsert());
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

            while (DatabaseConnection.CheckForPassword(Username, LogPassword))
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
