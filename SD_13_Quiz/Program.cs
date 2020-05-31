using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;

namespace SD_13_Quiz_ConsoleUI
{
    class Program
    {
        static void Main()
        {
            #region HANBA
            string locationOf = @".\..\..\..\SD_13_Quiz\packages\System.Data.SQLite.Core.1.0.112.2\build\net40\x86";
            string file = @"SQLite.Interop.dll";

            string debug = "";
            string destinationDLL = Path.Combine(debug, file);
            string existingDLL = Path.Combine(locationOf, file);

            if (File.Exists(existingDLL))
            {
                Process.Start("CMD");
                File.Copy(existingDLL, destinationDLL, true);
            }
            #endregion

            Console.WriteLine("Welcome to Hell");

            int escapeX3;
            do
            {
                MainMenu mainMenu = new MainMenu();
                escapeX3 = mainMenu.Start();

          
            } while (escapeX3 != 1);
            

            ConsoleKey exit;
            do
            {
                exit = Console.ReadKey().Key;

            } while (exit != ConsoleKey.Escape);


        }


    }
}
