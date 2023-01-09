using GameRpg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GameRpg
{
    //Menu avec Flèches + Enter
    class Menu
    {
        //Index sélectionner du menu
        private int SelectedIndex;
        //Array du contenu du menu
        private string[] Options;
        // Texte et item à faire apparaître
        private string Prompt;
        // Constructeur
        public Menu(string prompt, string[] options) 
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }  
        //Rendu du menu avec Flèches + Enter
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
 
                //Indicateur de selection du menu
                if (i == SelectedIndex)
                {
                    //Menu Selectionner
                    prefix = "*";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                }
                else
                {
                    prefix = " ";
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{prefix}<<{currentOption}>>");
            }
            Console.ResetColor();
        }
        //On execute ce que l'on a besoin a l'exterieur
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                //Vider la console
                Console.Clear();
                //Rendu du menu
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //Mettre à jour index selectionner Par rapport au flèches Haut/Bas
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if(SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            }// Boucle continue tant qu' Enter n'est pas appuyer
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

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
        public static void ClearLogo()
        {
            string logo = @"";
            Console.WriteLine(logo, Color.AliceBlue);
        }
    }
}



