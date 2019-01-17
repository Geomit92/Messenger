using System;

namespace MyMessenger
{
    class MessagesActions : Messages
    {
        internal static void EditMessage()
        {
            string user;
            ViewMessageWithId(out user);

            Console.Write("Select An ID: ");

            int ID;
            string stringID = Console.ReadLine();
            Int32.TryParse(stringID, out ID);

            while (!DatabaseConnection.CheckIDMessage(ID, user))
            {
                stringID = Console.ReadLine();
                Int32.TryParse(stringID, out ID);
            }

            Console.WriteLine("Edit Message: ");
            string Message = Console.ReadLine();
            while (Message.Length > 250)
            {
                Console.WriteLine("Your Message must Under 250 Character. Try Again ...");
                Message = Console.ReadLine();
            }

            DatabaseConnection.EditMessageDB(ID, Message);
            Console.WriteLine("\nMessage Edited.");
            WelcomeScreen.ConsoleClear();
        }

        internal static void EditMessage(string LogedUser)
        {
            if (DatabaseConnection.ViewForZeroMessage(LogedUser) == false )
            {
                DatabaseConnection.ViewMessageWithIdDB(LogedUser);
                    
                Console.Write("Select An ID: ");
                int ID;

                string stringID = Console.ReadLine();
                Int32.TryParse(stringID, out ID);

                while (!DatabaseConnection.CheckIDMessage(ID, LogedUser))
                {
                    stringID = Console.ReadLine();
                    Int32.TryParse(stringID, out ID);
                }

                Console.WriteLine("Edit Message: ");
                string Message = Console.ReadLine();
                while (Message.Length > 250)
                {
                    Console.WriteLine("Your Message must Under 250 Character. Try Again ...");
                    Message = Console.ReadLine();
                }

                DatabaseConnection.EditMessageDB(ID, Message);
            }
            else
            {
                Console.WriteLine("You dont have any Message...");
            }
            WelcomeScreen.ConsoleClear();
        }

        internal static void DeleteMessage()
        {
            string user;
            ViewMessageWithId(out user);

            Console.Write("Select An ID: ");

            int ID;
            string stringID = Console.ReadLine();
            Int32.TryParse(stringID, out ID);

            while (!DatabaseConnection.CheckIDMessage(ID, user))
            {
                stringID = Console.ReadLine();
                Int32.TryParse(stringID, out ID);
            }

            DatabaseConnection.DeleteMessageDB(ID);
        }

        internal static void DeleteMessage(string LogedUser)
        {
            if (DatabaseConnection.ViewForZeroMessage(LogedUser) == false)
            {
                DatabaseConnection.ViewMessageWithIdDB(LogedUser);

                Console.Write("Select An ID: ");

                int ID;
                string stringID = Console.ReadLine();
                Int32.TryParse(stringID, out ID);

                while (!DatabaseConnection.CheckIDMessage(ID, LogedUser))
                {
                    stringID = Console.ReadLine();
                    Int32.TryParse(stringID, out ID);
                }

                DatabaseConnection.DeleteMessageDB(ID);
            }
            else
            {
                Console.WriteLine("You Dont Have any Message to Delete...");
            }

            WelcomeScreen.ConsoleClear();
        }

        internal static void SendMessage(string LogedUser)
        {
            Console.WriteLine("Do you want to send a Message to: ");
            string ToUser = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(ToUser))
            {
                ToUser = Console.ReadLine();
            }

            Console.WriteLine("Write your Message: ");
            string Message = Console.ReadLine();
            while (Message.Length > 250)
            {
                Console.WriteLine("Your Message must be Under 250 Character. Try Again ...");
                Message = Console.ReadLine();
            }
            DatabaseConnection.SendMessageDB(Message, LogedUser, ToUser);
        }

        internal static void ViewMessage(string LogedUser)
        {
            DatabaseConnection.ViewMessageDB(LogedUser);

            WelcomeScreen.ConsoleClear();
        }

        internal static void ViewMessage()
        {
            Console.Clear();

            Console.WriteLine("Select A User: ");
            string user = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(user) || DatabaseConnection.ViewForZeroMessage(user))
            {
                user = Console.ReadLine();
            }

            DatabaseConnection.ViewMessageDB(user);

            WelcomeScreen.ConsoleClear();
        }

        internal static void ViewMessageWithId(out string user)
        {
            Console.Clear();

            Console.WriteLine("Select A User: ");
            user = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(user) || DatabaseConnection.ViewForZeroMessage(user))
            {
                user = Console.ReadLine();
            }
            
            DatabaseConnection.ViewMessageWithIdDB(user);
        }
    }
}
