using System;

namespace MyMessenger
{
    class AdminActions
    {
        public static void UpdateUsername()
        {
            Console.WriteLine("Give me the User You want to Change his/Her Username: ");
            string User = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(User))
            {
                Console.WriteLine("This User Does not Exist. Try Again...");
                User = Console.ReadLine();
            }

            Console.WriteLine("Give me a New Username: ");
            string NewUser = Console.ReadLine();
            while (DatabaseConnection.CheckAvailableName(NewUser))
            {
                Console.WriteLine("Give me Another Username");
                NewUser = Console.ReadLine();
            }

            int ID;
            DatabaseConnection.UsernameWithID(User, out ID);

            DatabaseConnection.UpdateUsernameDB(NewUser, ID);

            Design.ConsoleClear();
        }

        public static void UpdateUserPass()
        {
            Console.WriteLine("Give a Username: ");
            string Username = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(Username))
            {
                Console.WriteLine("This User doesn't exist. Try again...");
                Username = Console.ReadLine();
            }
            DatabaseConnection.UpdateUserPassDB(Username, Password.PasswordInsert());

            Design.ConsoleClear();
        }

        public static void DeleteUser()
        {
            Console.WriteLine("What User Do you want to Delete");
            string DeletedUser = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(DeletedUser))
            {
                Console.WriteLine("This User Doesn't Exist. Try Again...");
                DeletedUser = Console.ReadLine();
            }

            DatabaseConnection.DeleteUserDB(DeletedUser);

            Design.ConsoleClear();
        }
        
        public static void UpdateUserRole()
        {
            Console.WriteLine("Which User do you want to Change his/her Role");
            String Username = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(Username))
            {
                Console.WriteLine("This User Doesn't Exist. Try Again...");
                Username = Console.ReadLine();
            }

            Console.WriteLine("Select A Role:");
            Console.WriteLine("Admin - Mod - Loyal - Friend - Guest");
            String UserRole = Console.ReadLine();

            while (UserRole != "Admin" && UserRole != "Mod" && UserRole != "Loyal" && UserRole != "Friend" && UserRole != "Guest")
            {
                Console.WriteLine("Wrong Role. Try Again");
                UserRole = Console.ReadLine();
            }

            DatabaseConnection.UpdateUserRoleDB(Username, UserRole);

            Design.ConsoleClear();
        }
    }
}
