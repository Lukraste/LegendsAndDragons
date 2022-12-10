using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameRpg
{
    class MainMenu
    {
        public static void Menu()
        {

            for(; ; )
            {
                Console.Clear();
                WriteLogo();
                Say("1", "New Game");
                Say("2", "Save Game");
                Say("3", "Load Game");
                Say("4", "Exit Game");
                string? input = Console.ReadLine();
                string option = input;
                if (option == "1")
                {
                    //New Game
                }
                else if(option == "2") 
                {
                    //Save Game
                }
                else if(option == "3") 
                {
                    //Load Game
                }
                else if(option == "4")
                {
                    //Exit Game
                    
                }
                else
                {
                    Console.WriteLine("Erreur, choisiser l'une des options possible");
                    Thread.Sleep(1500);
                }
            }
        }
        public static void Say(string prefix, string message) 
        {
            Console.Write("[");
            Console.Write(prefix, Color.BlueViolet);
            Console.WriteLine("]" + message);
        }
        public static void WriteLogo()
        {
            string logo = @"

              _                               _                        _        _                                 
 | |                             | |                      | |      | |                                
 | |     ___  __ _  ___ _ __   __| |___     __ _ _ __   __| |    __| |_ __ __ _  __ _  ___  _ __  ___ 
 | |    / _ \/ _` |/ _ \ '_ \ / _` / __|   / _` | '_ \ / _` |   / _` | '__/ _` |/ _` |/ _ \| '_ \/ __|
 | |___|  __/ (_| |  __/ | | | (_| \__ \  | (_| | | | | (_| |  | (_| | | | (_| | (_| | (_) | | | \__ \
 |______\___|\__, |\___|_| |_|\__,_|___/   \__,_|_| |_|\__,_|   \__,_|_|  \__,_|\__, |\___/|_| |_|___/
              __/ |                                                              __/ |                
             |___/                                                              |___/                           

            ";
            Console.WriteLine(logo, Color.AliceBlue);
        }
    }
}



