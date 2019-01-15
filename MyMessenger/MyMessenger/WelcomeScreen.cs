using System;

namespace MyMessenger
{
    class WelcomeScreen
    {
        public static void WelcomeMethod()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Welc = (@"
 __        _______ _     ____ ___  __  __ _____    ____ _____ ____     _    _   _  ____ _____ ____  
 \ \      / | ____| |   / ___/ _ \|  \/  | ____|  / ___|_   _|  _ \   / \  | \ | |/ ___| ____|  _ \ 
  \ \ /\ / /|  _| | |  | |  | | | | |\/| |  _|    \___ \ | | | |_) | / _ \ |  \| | |  _|  _| | |_) |
   \ V  V / | |___| |__| |__| |_| | |  | | |___    ___) || | |  _ < / ___ \| |\  | |_| | |___|  _ < 
    \_/\_/  |_____|_____\____\___/|_|  |_|_____|  |____/ |_| |_| \_/_/   \_|_| \_|\____|_____|_| \_\
                                                                                                    
            ");

            Console.WriteLine(Welc);

            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void WelcomeMethod1()
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

            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void ConsoleClear()
        {
            Console.WriteLine("\nType Anything to Continue...\n");
            Console.ReadLine();
            Console.Clear(); 
        }
    }
}
