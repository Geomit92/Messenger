using System;

namespace MyMessenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var CheckDB = new DatabaseConnection();
            while (CheckDB.DbConn())
            {
                var menus = new Menus();
                while (menus.LoginMenu())
                { }
            }
        }
    }
}
