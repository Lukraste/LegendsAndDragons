using GameRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRpg
{
    class Login
    {
        static void Main(string[] args)
        {
            Console.Title = "Legends and Dragons";
            // Text
            MainMenu.Menu();
            MainMenu.WriteLogo();
            Console.WriteLine("Bienvenue");
            Console.ReadKey(true);
        }
    }
}
