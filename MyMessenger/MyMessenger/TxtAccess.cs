using System;
using System.IO;

namespace MyMessenger
{
    public class TxtAccess
    {
        private static string TxtPath = Properties.Settings.Default.TxtPath;

        internal static void FileCreation(string sender,string receiver,string message)
        {
            string TxtTittle = $"{sender} send to {receiver}.txt";

            try
            {
                if (!File.Exists(TxtPath + TxtTittle))
                {
                    StreamWriter sw = File.CreateText(TxtPath + TxtTittle);
                    using (sw)
                    {
                        sw.WriteLine($"{message} at {System.DateTime.Now} \n");
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(TxtPath + TxtTittle, true))
                    {
                        sw.WriteLine($"{message} at {System.DateTime.Now} \n");
                    }
                }
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went Wrong with the creation of TXT files.");
                Console.ResetColor();
            }
        }
    }

}
