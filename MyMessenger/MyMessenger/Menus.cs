using System;
using System.Threading;

namespace MyMessenger
{
    class Menus
    {
        public bool LoginMenu()
        {
                Console.Clear();
                WelcomeScreen.WelcomeMethod1();

                Console.WriteLine("-- Welcome to MITROCOMM --");
                Console.WriteLine("1. Login");
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
                        Console.WriteLine("Application Will Close...");
                        Thread.Sleep(2500);
                        Environment.Exit(0);
                        return false;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
        }

        public static void AdminMenu(string LogedUser)
        {
        Start:
            

            Console.WriteLine($"-- Welcome {LogedUser} --\n");
            
            Console.WriteLine("1. User's Action's");
            Console.WriteLine("2. Send Message");
            Console.WriteLine("3. Inbox");
            Console.WriteLine("4. Edit Your Message");
            Console.WriteLine("5. Delete Your Message");
            Console.WriteLine("6. Log-Off");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        Menus.AdminActionsMenu(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.SendMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.ViewMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "4":
                        MessagesActions.EditMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "5":
                        MessagesActions.DeleteMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "6":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:;
           
        }

        public static void AdminActionsMenu(string LogedUser)
        {
            Console.Clear();
        Start:
            

            Console.WriteLine("Admin's Action's");

            Console.WriteLine("1. Create a User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Update A User's Name");
            Console.WriteLine("4. Update A User's Password");
            Console.WriteLine("5. Update A User's Role");
            Console.WriteLine("6. Delete A User");
            Console.WriteLine("7. Return ");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        LoginSignUP.SignUp();
                        SwitchCheck = false;
                        break;

                    case "2":
                        DatabaseConnection.ShowAllUsersDB();
                        SwitchCheck = false;
                        break;

                    case "3":
                        AdminActions.UpdateUsername();

                        SwitchCheck = false;
                        break;

                    case "4":
                        AdminActions.UpdateUserPass();
                        SwitchCheck = false;
                        break;

                    case "5":
                        AdminActions.UpdateUserRole();
                        SwitchCheck = false;
                        break;

                    case "6":
                        AdminActions.DeleteUser();
                        SwitchCheck = false;
                        break;

                    case "7":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:;
            
        }

        public static void ModMenu(string LogedUser)
        {
        Start:

            Console.Clear();

            Console.WriteLine($"-- Welcome {LogedUser} --\n");

            Console.WriteLine("1. Role Action's");
            Console.WriteLine("2. Send Message");
            Console.WriteLine("3. Inbox");
            Console.WriteLine("4. Edit Your Message");
            Console.WriteLine("5. Delete Your Message");
            Console.WriteLine("6. Log-Off");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        Menus.ModActionsMenu(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.SendMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.ViewMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "4":
                        MessagesActions.EditMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "5":
                        MessagesActions.DeleteMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "6":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void ModActionsMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine("-------- Mod's Action's ---------");
            Console.WriteLine("1.  View  --> A User's Messages");
            Console.WriteLine("2.  Edit  --> A User's Messages");
            Console.WriteLine("3. Delete --> A User's Messages");
            Console.WriteLine("4. ----------- Return ----------- ");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        string user;
                        MessagesActions.ViewMessageWithId(out user);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.EditMessage();
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.DeleteMessage();
                        SwitchCheck = false;
                        break;

                    case "4":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void LoyalMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine($"-- Welcome {LogedUser} --\n");

            Console.WriteLine("1. User's Action's");
            Console.WriteLine("2. Send Message");
            Console.WriteLine("3. Inbox");
            Console.WriteLine("4. Edit Your Message");
            Console.WriteLine("5. Delete Your Message");
            Console.WriteLine("6. Log-Off");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        Menus.LoyalActionsMenu(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.SendMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.ViewMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "4":
                        MessagesActions.EditMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "5":
                        MessagesActions.DeleteMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "6":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void LoyalActionsMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine("---- Loyal's Action's -----");
            Console.WriteLine("1.  View  A User's Messages");
            Console.WriteLine("2.  Edit  A User's Messages");
            Console.WriteLine("3. Return ");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        string user;
                        MessagesActions.ViewMessageWithId(out user);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.EditMessage();
                        SwitchCheck = false;
                        break;

                    case "3":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void FriendMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine($"-- Welcome {LogedUser} --\n");

            Console.WriteLine("1. User's Action's");
            Console.WriteLine("2. Send Message");
            Console.WriteLine("3. Inbox");
            Console.WriteLine("4. Edit Your Message");
            Console.WriteLine("5. Delete Your Message");
            Console.WriteLine("6. Log-Off");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        Menus.FriendActionsMenu(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.SendMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.ViewMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "4":
                        MessagesActions.EditMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "5":
                        MessagesActions.DeleteMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "6":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void FriendActionsMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine("---- Friend's Action's -----");
            Console.WriteLine("1. View  A User's Messages");
            Console.WriteLine("2. Return ");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        string user;
                        MessagesActions.ViewMessageWithId(out user);
                        SwitchCheck = false;
                        break;

                    case "2":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }

        public static void GuestMenu(string LogedUser)
        {
        Start:
            Console.Clear();

            Console.WriteLine($"-- Welcome {LogedUser} --\n");
            
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. Inbox");
            Console.WriteLine("3. Edit Your Message");
            Console.WriteLine("4. Delete Your Message");
            Console.WriteLine("5. Log-Off");

            bool SwitchCheck = true;
            while (SwitchCheck)
                switch (Console.ReadLine())
                {
                    case "1":
                        MessagesActions.SendMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "2":
                        MessagesActions.ViewMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "3":
                        MessagesActions.EditMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "4":
                        MessagesActions.DeleteMessage(LogedUser);
                        SwitchCheck = false;
                        break;

                    case "5":
                        goto LoginMenu;
                        SwitchCheck = false;
                        break;

                    default:
                        Console.WriteLine("Your Input dont match , Choose Again...");
                        break;
                }
            goto Start;
        LoginMenu:
            Console.Clear();
        }
    }
}
