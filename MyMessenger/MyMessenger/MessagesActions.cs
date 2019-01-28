using System;

namespace MyMessenger
{
    class MessagesActions : Messages
    {
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

        internal static void CheckID(string user , out int ID)
        {
            string stringID = Console.ReadLine();
            Int32.TryParse(stringID, out ID);

            while (!DatabaseConnection.CheckIDMessage(ID, user))
            {
                stringID = Console.ReadLine();
                Int32.TryParse(stringID, out ID);
            }
        }

        internal static void EditMessage()
        {
            Console.Clear();
            string user;
            ViewMessageWithId(out user);

            Console.Write("Select An ID: ");
            int ID;
            CheckID(user , out ID);

            Console.WriteLine("Edit Message: ");
            string Message = Console.ReadLine();
            while (Message.Length > 250)
            {
                Console.WriteLine("Your Message must Under 250 Character. Try Again ...");
                Message = Console.ReadLine();
            }

            DatabaseConnection.EditMessageDB(ID, Message);
            Design.ConsoleClear();
        }

        internal static void EditMessage(string LogedUser)
        {
            if (DatabaseConnection.ViewForZeroMessage(LogedUser) == false )
            {
                DatabaseConnection.ViewMessageWithIdDB(LogedUser);
                    
                Console.Write("Select An ID: ");
                int ID;
                CheckID(LogedUser, out ID);

                Console.WriteLine("Edit Message: ");
                string Message = Console.ReadLine();
                while (Message.Length > 250)
                {
                    Console.WriteLine("Your Message must Under 250 Character. Try Again ...");
                    Message = Console.ReadLine();
                }

                DatabaseConnection.EditMessageDB(ID, Message);
            }

            Design.ConsoleClear();
        }

        internal static void DeleteMessage()
        {
            string user;
            ViewMessageWithId(out user);

            Console.Write("Select An ID: ");
            int ID;
            CheckID(user, out ID);

            DatabaseConnection.DeleteMessageDB(ID);
        }

        internal static void DeleteMessage(string LogedUser)
        {
            if (DatabaseConnection.ViewForZeroMessage(LogedUser) == false)
            {
                DatabaseConnection.ViewMessageWithIdDB(LogedUser);

                Console.Write("Select An ID: ");
                int ID;
                CheckID(LogedUser, out ID);

                DatabaseConnection.DeleteMessageDB(ID);
            }

            Design.ConsoleClear();
        }

        internal static void ViewMessage()
        {
            Console.Clear();

            Console.WriteLine("Select A User: ");
            string user = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(user) || DatabaseConnection.ViewForZeroMessage(user))
            {
                Console.WriteLine("Select Again:");
                user = Console.ReadLine();
            }

            DatabaseConnection.ViewMessageWithIdDB(user);

            Design.ConsoleClear();
        }

        internal static void ViewMessage(string LogedUser)
        {
            DatabaseConnection.ViewMessageDB(LogedUser);

            Design.ConsoleClear();
        }

        internal static void ViewMessageWithId(out string user)
        {
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
