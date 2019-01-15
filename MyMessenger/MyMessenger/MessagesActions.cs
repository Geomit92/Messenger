using System;

namespace MyMessenger
{
    class MessagesActions : Messages
    {
        public static void EditMessage()
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
        }

        public static void EditMessage(string LogedUser)
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

        public static void DeleteMessage()
        {
            Console.WriteLine("Select A User to Delete his Message: ");
            string user = Console.ReadLine();
            
            while (DatabaseConnection.CheckUserList(user) || DatabaseConnection.ViewForZeroMessage(user))
            {
                user = Console.ReadLine();
            }

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

        public static void DeleteMessage(string LogedUser)
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

        public static void SendMessage(string LogedUser)
        {
            Console.WriteLine("Do you want to send a Message to: ");
            string ToUser = Console.ReadLine();
            while (DatabaseConnection.CheckUserList(ToUser))
            {
                Console.WriteLine("User doesnt Exist...Try again.");
                ToUser = Console.ReadLine();
            }

            Console.WriteLine("Write your Message: ");
            string Message = Console.ReadLine();
            while (Message.Length > 250)
            {
                Console.WriteLine("Your Message must be Under 250 Character. Try Again ...");
                Message = Console.ReadLine();
            }
            var Mes = new DatabaseConnection();
            Mes.SendMessageDB(Message, LogedUser, ToUser);
            //DatabaseConnection.SendMessageDB(Message, LogedUser, ToUser);
        }

        public static void ViewMessage(string LogedUser)
        {
            DatabaseConnection.ViewMessageDB(LogedUser);

            WelcomeScreen.ConsoleClear();
        }

        public static void ViewMessageWithId(out string user)
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
