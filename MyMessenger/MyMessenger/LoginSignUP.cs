using System;
using System.Threading;

namespace MyMessenger
{
    class LoginSignUP
    {
        public static void Login()
        {
            Console.Clear();
            WelcomeScreen.WelcomeMethod1();

            string LogedUser;

            InsertUsernamePassword(out LogedUser);

            if (DatabaseConnection.CheckUserRole(LogedUser) == "Admin")
            {
                Menus.AdminMenu(LogedUser);
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Mod")
            {
                Menus.ModMenu(LogedUser);
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Loyal")
            {
                Menus.LoyalMenu(LogedUser);
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Friend")
            {
                Menus.FriendMenu(LogedUser);
            }
            else if (DatabaseConnection.CheckUserRole(LogedUser) == "Guest")
            {
                Menus.GuestMenu(LogedUser);
            }
        }

        public static void SignUp()
        {
            Console.Clear();
            WelcomeScreen.WelcomeMethod1();

            Console.WriteLine("Sign-Up");
            Console.WriteLine("Give me Your username");

            string Name = Console.ReadLine();

            while (DatabaseConnection.CheckAvailableName(Name))
            {
                Console.WriteLine("Give me Another Username \nor Type (e) to Restart the App");
                Name = Console.ReadLine();
                if (Name == "e")
                {
                    //goto Restart;
                    return;
                }
            }
            DatabaseConnection.CreateUserDB(Name, Password.PasswordInsert());
            //Restart:;
        }

        public static void InsertUsernamePassword(out string LogedUser)
        {
            Console.WriteLine("Give me your Username: ");
            string Username = Console.ReadLine();

            int TriesUser = 2;
            int TriesPass = 2;

            while (DatabaseConnection.CheckUserList(Username))
            {
                if (TriesUser >= 1)
                {
                    Console.WriteLine("This User doesn't exist. Try again...");
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
