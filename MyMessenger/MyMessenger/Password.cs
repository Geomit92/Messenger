using System;
using System.Threading;

namespace MyMessenger
{
    public class Password
    {
        public static string PasswordInsert()
        {
            
            Console.WriteLine("Give me a Password");
            string Password = HidePassword();
            while (PassCheck(Password))
            {
                Console.WriteLine("Give me a Password Again...");
                Password = HidePassword();
            }

            Console.WriteLine("Give me your Password Again: ");
            string Password1 = HidePassword();

            int Tries = 2;
            while (Password != Password1)
            {
                if (Tries >= 1)
                {
                    Console.WriteLine("Passwords does not Match , Try Again...");
                    Console.WriteLine($"Remaining Tries: {Tries}");
                    Password1 = HidePassword();
                    Tries -= 1;
                }
                else
                {
                    Console.WriteLine("Application Will Close. Try Again Later...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            }
            return Password;
        }

        public static bool PassCheck(string Password)
        {
            Console.BackgroundColor = ConsoleColor.Red;

            if (Password.Length < 4 || Password.Length > 8)
            {
                Console.WriteLine("Password must be between 4 and 8 digits. Try Again...");
                Console.ResetColor();

                return true;
            }
            if (Password.Contains(" "))
            {
                Console.WriteLine("Password Cannot Contain Whitespaces. Try Again...");
                Console.ResetColor();

                return true;
            }
            
            Console.ResetColor();
            return false;
        }

        public static string HidePassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("x");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(" ");
            return pass;
        }
    }
}
