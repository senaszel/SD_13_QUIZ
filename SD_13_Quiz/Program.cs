using System;
using System.Collections.Generic;
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
