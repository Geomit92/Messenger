using System;
using System.Collections.Generic;

namespace MyMessenger
{
    class AdminActions
    {
        internal void UpdateUsername()
        {
            Console.WriteLine("Give me the User You want to Change his/Her Username: ");
            string User = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(User))
            {
                User = Console.ReadLine();
            }

            Console.WriteLine("Give me a New Username: ");
            string NewUser = Console.ReadLine();
            while (DatabaseConnection.CheckAvailableName(NewUser))
            {
                Console.WriteLine("Give me Another Username");
                NewUser = Console.ReadLine();
            }

            IEnumerable<int> ID;
            DatabaseConnection.UsernameWithID(User, out ID);

            DatabaseConnection.UpdateUsernameDB(NewUser, ID);

            Design.ConsoleClear();
        }

        internal void UpdateUserPass()
        {
            Console.WriteLine("Give a Username: ");
            string Username = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(Username))
            {
                Username = Console.ReadLine();
            }
            DatabaseConnection.UpdateUserPassDB(Username, Password.PasswordInsert());

            Design.ConsoleClear();
        }

        internal void DeleteUser()
        {
            Console.WriteLine("What User Do you want to Delete");
            string DeletedUser = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(DeletedUser))
            {
                DeletedUser = Console.ReadLine();
            }

            DatabaseConnection.DeleteUserDB(DeletedUser);

            Design.ConsoleClear();
        }
        
        internal void UpdateUserRole()
        {
            Console.WriteLine("Which User do you want to Change his/her Role");
            String Username = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(Username))
            {
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
