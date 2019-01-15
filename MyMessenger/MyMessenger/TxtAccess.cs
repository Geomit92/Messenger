using System;
using System.IO;

namespace MyMessenger
{
    public class TxtAccess
    {
        private static string TxtPath = @"C:\Users\Geomit\source\repos\";

        public static void FileCreation(string sender,string receiver,string message)
        {
            string TxtTittle = $"{sender} send to {receiver} Message.txt";


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
    }

}
