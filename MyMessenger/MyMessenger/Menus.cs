using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMessenger
{
    class Menus
    {
        internal bool LoginMenu()
        {
                Console.Clear();
                WelcomeScreen.WelcomeMethod();
            
                Console.WriteLine("\n1. Login");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");

                while (true)
                switch (Console.ReadLine())
                {
                    case "1":
                        LoginSignUP.Login();
                        Console.Clear();
                        return true;

                    case "2":
                        LoginSignUP.SignUp();
                        Console.Clear();
                        return true;

                    case "3":
                        WelcomeScreen.ConsoleExit();
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
        }

        internal bool GeneralMenu(string LogedUser)
        {
            WelcomeScreen.MiniWelc(LogedUser);
            
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. Inbox");
            Console.WriteLine("3. Edit Your Message");
            Console.WriteLine("4. Delete Your Message");
            Console.WriteLine("5. Actions");
            Console.WriteLine("6. Log-Off");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        MessagesActions.SendMessage(LogedUser);
                        Console.Clear();
                        return true;
                        
                    case "2":
                        MessagesActions.ViewMessage(LogedUser);
                        Console.Clear();
                        return true;

                    case "3":
                        MessagesActions.EditMessage(LogedUser);
                        Console.Clear();
                        return true;

                    case "4":
                        MessagesActions.DeleteMessage(LogedUser);
                        Console.Clear();
                        return true;

                    case "5":
                        Console.Clear();
                        LoginSignUP.RoleMenu(LogedUser);
                        return true;

                    case "6":
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            }
        }
        
        internal bool AdminActionsMenu(string LogedUser)
        {
            WelcomeScreen.AdminDesign();
            
            Console.WriteLine("1. Create A User");
            Console.WriteLine("2.  View  All Users");
            Console.WriteLine("3. Update A User's Name");
            Console.WriteLine("4. Update A User's Password");
            Console.WriteLine("5. Update A User's Role");
            Console.WriteLine("6. Delete A User");
            Console.WriteLine("7. Return ");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        LoginSignUP.SignUp();
                        Console.Clear();
                        return true;

                    case "2":
                        DatabaseConnection.ShowAllUsers();
                        Console.Clear();
                        return true;

                    case "3":
                        AdminActions.UpdateUsername();
                        Console.Clear();
                        return true;

                    case "4":
                        AdminActions.UpdateUserPass();
                        Console.Clear();
                        return true;

                    case "5":
                        AdminActions.UpdateUserRole();
                        Console.Clear();
                        return true;

                    case "6":
                        AdminActions.DeleteUser();
                        Console.Clear();
                        return true;

                    case "7":
                        return false;
                        
                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            }
        }
        
        internal bool ModActionsMenu(string LogedUser)
        {
            Console.Clear();
            WelcomeScreen.ModDesign();

            Console.WriteLine("1.  View  --> A User's Messages");
            Console.WriteLine("2.  Edit  --> A User's Messages");
            Console.WriteLine("3. Delete --> A User's Messages");
            Console.WriteLine("4. Return ");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        MessagesActions.ViewMessage();
                        Console.Clear();
                        return true;

                    case "2":
                        MessagesActions.EditMessage();
                        Console.Clear();
                        return true;

                    case "3":
                        MessagesActions.DeleteMessage();
                        Console.Clear();
                        return true;

                    case "4":
                        Console.Clear();
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            }
        }
        
        internal bool LoyalActionsMenu(string LogedUser)
        {
            Console.Clear();
            WelcomeScreen.LoyalDesign();

            Console.WriteLine("1.  View  --> A User's Messages");
            Console.WriteLine("2.  Edit  --> A User's Messages");
            Console.WriteLine("3. Return ");

            
            while (true)
            { 
                switch (Console.ReadLine())
                {
                    case "1":
                        MessagesActions.ViewMessage();
                        Console.Clear();
                        return true;

                    case "2":
                        MessagesActions.EditMessage();
                        Console.Clear();
                        return true;

                    case "3":
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            }
        }
        
        internal bool FriendActionsMenu(string LogedUser)
        {
            Console.Clear();
            WelcomeScreen.FriendDesign();

            Console.WriteLine("1.  View  --> A User's Messages");
            Console.WriteLine("2. Return ");
            
            while (true)
            { 
                switch (Console.ReadLine())
                {
                    case "1":
                        MessagesActions.ViewMessage();
                        Console.Clear();
                        return true;

                    case "2":
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            }
        }
        
    }
}
