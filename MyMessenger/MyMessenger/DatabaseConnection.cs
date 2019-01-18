using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Threading;
using System.Linq;

namespace MyMessenger
{
    class DatabaseConnection
    {
        #region Messages And Database

        private static string connectionstring = Properties.Settings.Default.connectionstring;

        internal static void EditMessageDB(int ID, string Message)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("UPDATE Messages SET UserMessage = @UserMessage WHERE MessageID = @MessageID",
                    new
                    {
                        UserMessage = Message,
                        MessageId = ID
                    });
            }
        }

        internal static bool CheckIDMessage(int ID, string user)
        {
            var IDMessage = new List<MessagesActions>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                IDMessage.AddRange(dbcon.Query<MessagesActions>("SELECT * FROM Messages WHERE Sender=@Sender",
                    new
                    {
                        Sender = user,
                    }));
            }

            foreach (var m in IDMessage)
            {
                while (m.MessageID.Equals(ID))
                {
                    return true;
                }
            }

            Console.WriteLine("Wrong ID. Try Again...");
            return false;
        }

        internal static void SendMessageDB(string UserMessage, string Sender, string Receiver)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("insert into Messages values(@Date,@Sender, @Receiver, @UserMessage, @Deleted)",
                    new
                    {
                        Date = DateTime.Now,
                        Sender = Sender,
                        Receiver = Receiver,
                        UserMessage = UserMessage,
                        Deleted = 0,
                    });
            }

            TxtAccess.FileCreation(Sender, Receiver, UserMessage);

            Console.WriteLine("\nYour Message Send Successfully");

            WelcomeScreen.ConsoleClear();
        }

        internal static void ViewMessageDB(string Sender)
        {
            var SendMessage = new List<MessagesActions>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                SendMessage.AddRange(dbcon.Query<MessagesActions>("SELECT * FROM Messages WHERE Receiver=@Receiver",
                    new
                    {
                        Receiver = Sender,
                    }));
            }
            if (SendMessage.Count == 0)
            {
                Console.WriteLine("\nNo Message Loaded.");
            }
            else
            {
                foreach (var m in SendMessage)
                {
                    if (m.Deleted == false)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"\n{m.Sender} Send you:");
                        Console.ResetColor();
                        Console.WriteLine($"{m.UserMessage} \nAt {m.Date.ToString("dd/MM HH:mm")}");
                    }
                }
            }
        }

        internal static void ViewMessageWithIdDB(string user)
        {
            var ViewMessage = new List<MessagesActions>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                ViewMessage.AddRange(dbcon.Query<MessagesActions>("SELECT * FROM Messages WHERE Sender=@Sender",
                    new
                    {
                        Sender = user,
                    }));
            }
            if (ViewMessage.Count == 0)
            {
                Console.WriteLine("No Messages Loaded");
            }
            else
            {
                foreach (var m in ViewMessage)
                {
                    if (m.Deleted == false)
                    {
                        Console.WriteLine($"ID:{m.MessageID}: {m.Sender} Send: \n{m.UserMessage} \nAt {m.Receiver}\n");
                    }
                }
            }
        }

        internal static bool ViewForZeroMessage(string user)
        {
            var ViewMessage = new List<MessagesActions>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                ViewMessage.AddRange(dbcon.Query<MessagesActions>("SELECT * FROM Messages WHERE Sender=@Sender",
                    new
                    {
                        Sender = user,
                    }));
            }

            if (ViewMessage.Count == 0)
            {
                Console.WriteLine("\nNo Message Loaded.");
                return true;
            }
            return false;
        }

        internal static void DeleteMessageDB(int ID)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("UPDATE Messages SET Deleted = @Deleted WHERE MessageID = @MessageID",
                    new
                    {
                        Deleted = 1,
                        MessageId = ID
                    });
            }
            Console.WriteLine("\nMessage Deleted");
        }

        #endregion

        #region Users And Database

        internal static string CheckUserRole(string LogedUser)
        {
            var users = new List<Users>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                users.AddRange(dbcon.Query<Users>("SELECT * FROM Users WHERE Username = @Username",
                    new
                    {
                        Username = LogedUser,
                    }));
            }

            foreach (var c in users)
            {
                return c.Role;
            }
            return "Guest";
        }

        internal static bool CheckUserList(string name)
        {
            var db = new DatabaseConnection();
            bool check = db.SelectAllUsers()
                .Any(u => u.Username == name && u.Deleted == false);

            if (check == true)
            {
                return false;
            }
            else
            {
                Console.WriteLine("This User Doesn't Exist... Try Again.");
                return true;
            }
        }

        internal static bool CheckForPassword(string Username, string Password)
        {
            var users = new List<Users>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                users.AddRange(dbcon.Query<Users>("SELECT * FROM Users WHERE Username = @Username",
                    new
                    {
                        Username = Username,
                    }));
            }
            foreach (var u in users)
            {
                if (Password == u.Password)
                {
                    return false;
                }
            }
            return true;
        }

        internal static void CreateUserDB(string NewUsername, string NewPassword)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("insert into Users values(@username, @password, @Role, @Deleted)",
                    new
                    {
                        Username = NewUsername,
                        Password = NewPassword,
                        Role = "Guest",
                        Deleted = 0,
                    });
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"User: {NewUsername} Created successfully");
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        internal static void ShowAllUsers()
        {
            var db = new DatabaseConnection();
            var users = db.SelectAllUsers()
                .Where(x => x.Deleted == false)
                .OrderBy(x => x.Role)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Role}: {user.Username}");
            }

            WelcomeScreen.ConsoleClear();
        }

        internal static void UsernameWithID(string Username, out int ID)
        {
            ID = 0;
            var users = new List<Users>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                users.AddRange(dbcon.Query<Users>("SELECT * FROM Users WHERE Username = @Username",
                    new
                    {
                        Username = Username,
                    }));
            }

            foreach (var u in users)
            {
                ID = u.UsernameID;
            }
        }

        internal static void UpdateUsernameDB(string NewUser, int ID)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("UPDATE Users SET Username = @Username WHERE UsernameID = @UsernameID",
                    new
                    {
                        Username = NewUser,
                        UsernameID = ID,
                    });
            }
        }

        internal static void UpdateUserPassDB(string Username, string Password)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var users = dbcon.Query("UPDATE Users SET Password = @Password where Username=@Username", new
                {
                    Password = Password,
                    Username = Username,

                });
            }
        }

        internal static void DeleteUserDB(string Username)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("UPDATE Users SET Deleted = @Deleted WHERE Username = @Username",
                    new
                    {
                        Deleted = 1,
                        Username = Username
                    });
            }
        }

        internal static void UpdateUserRoleDB(string Username, string Role)
        {
            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                var NewQuerry = dbcon.Execute("UPDATE Users SET Role = @Role WHERE Username = @Username",
                    new
                    {
                        Role = Role,
                        Username = Username,
                    });
            }
        }

        #endregion

        internal static bool CheckAvailableName(string NewUsername)
        {
            Console.BackgroundColor = ConsoleColor.Red;

            var Usernamelist = new List<Users>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                Usernamelist.AddRange(dbcon.Query<Users>("SELECT Username FROM Users"));
            }

            foreach (var c in Usernamelist)
            {
                if (NewUsername == c.Username)
                {
                    Console.WriteLine("This Username Already Taken. Try Again...");
                    Console.ResetColor();
                    return true;
                }
                else if (NewUsername.Contains(" "))
                {
                    Console.WriteLine("Username Cannot Contain whiteSpaces");
                    Console.ResetColor();
                    return true;
                }
                else if (NewUsername.Length < 5 || NewUsername.Length > 10)
                {
                    Console.WriteLine("Username must between 5 and 10 Characters. Try Again...");
                    Console.ResetColor();
                    return true;
                }
            }
            Console.ResetColor();
            return false;
        }

        internal List<Users> SelectAllUsers()
        {
            var user = new List<Users>();

            using (SqlConnection dbcon = new SqlConnection(connectionstring))
            {
                user = dbcon.Query<Users>("SELECT * FROM Users").ToList();
            }
            return user;
        }

        internal bool DbConn()
        {
            try
            {
                using (SqlConnection dbcon = new SqlConnection(connectionstring))
                {
                    dbcon.Open();
                    using (SqlCommand querry = new SqlCommand("SELECT * FROM sys.Databases where Name = 'Private_Messenger'", dbcon))
                    {
                        int Exist = querry.ExecuteNonQuery();

                        if (Exist > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong with DataBase");
                WelcomeScreen.ConsoleClear();
                return false;
            }
        }
    }
}
