using System;
using System.Threading;

namespace MyMessenger
{
    class WelcomeScreen
    {
        #region Designs

        public static void AdminDesign()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"
    ___       __          _     
   /   | ____/ /___ ___  (_)___ 
  / /| |/ __  / __ `__ \/ / __ \
 / ___ / /_/ / / / / / / / / / /
/_/  |_\__,_/_/ /_/ /_/_/_/ /_/ 
                                                                                                     
            ");
            Console.WriteLine(Welc);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ModDesign()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"
    __  ___          __
   /  |/  /___  ____/ /
  / /|_/ / __ \/ __  / 
 / /  / / /_/ / /_/ /  
/_/  /_/\____/\__,_/   
                                                                                                     
            ");
            Console.WriteLine(Welc);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LoyalDesign()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"
    __                      __
   / /   ____  __  ______ _/ /
  / /   / __ \/ / / / __ `/ / 
 / /___/ /_/ / /_/ / /_/ / /  
/_____/\____/\__, /\__,_/_/   
            /____/             
                                                                                                     
            ");
            Console.WriteLine(Welc);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void FriendDesign()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"
    ______     _                __
   / ____/____(_)__  ____  ____/ /
  / /_  / ___/ / _ \/ __ \/ __  / 
 / __/ / /  / /  __/ / / / /_/ /  
/_/   /_/  /_/\___/_/ /_/\__,_/   
                                                                                                    
            ");
            Console.WriteLine(Welc);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WelcomeMethod()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"

 ███▄ ▄███▓██▄▄▄█████▓██▀███  ▒█████  ▄████▄  ▒█████  ███▄ ▄███▓███▄ ▄███▓
▓██▒▀█▀ ██▓██▓  ██▒ ▓▓██ ▒ ██▒██▒  ██▒██▀ ▀█ ▒██▒  ██▓██▒▀█▀ ██▓██▒▀█▀ ██▒
▓██    ▓██▒██▒ ▓██░ ▒▓██ ░▄█ ▒██░  ██▒▓█    ▄▒██░  ██▓██    ▓██▓██    ▓██░
▒██    ▒██░██░ ▓██▓ ░▒██▀▀█▄ ▒██   ██▒▓▓▄ ▄██▒██   ██▒██    ▒██▒██    ▒██ 
▒██▒   ░██░██░ ▒██▒ ░░██▓ ▒██░ ████▓▒▒ ▓███▀ ░ ████▓▒▒██▒   ░██▒██▒   ░██▒
░ ▒░   ░  ░▓   ▒ ░░  ░ ▒▓ ░▒▓░ ▒░▒░▒░░ ░▒ ▒  ░ ▒░▒░▒░░ ▒░   ░  ░ ▒░   ░  ░
░  ░      ░▒ ░   ░     ░▒ ░ ▒░ ░ ▒ ▒░  ░  ▒    ░ ▒ ▒░░  ░      ░  ░      ░
░      ░   ▒ ░ ░       ░░   ░░ ░ ░ ▒ ░       ░ ░ ░ ▒ ░      ░  ░      ░   
       ░   ░            ░        ░ ░ ░ ░         ░ ░        ░         ░   
                                     ░                                  
            ");

            Console.WriteLine(Welc);
            Console.ResetColor();
        }
        #endregion


        public static void MiniWelc(string LogedUser)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------");
            Console.WriteLine($"\tWelcome {LogedUser}\n");
            Console.WriteLine("------------------------------\n");
            Console.ResetColor();
        }

        public static void ConsoleClear()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nType Anything to Continue...\n");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear(); 
        }

        public static void ConsoleExit()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nApplication Will Close...\n");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }
    }
}
