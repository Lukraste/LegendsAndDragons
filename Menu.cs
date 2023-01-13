using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LegendsAndDragons
{
    //Menu avec Flèches + Enter
    class Menu
    {
        //Index sélectionner du menu
        public int SelectedIndex { get; set; }
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
        public void DisplayOptions()
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
        public ConsoleKey Indexation(ConsoleKey keyPressed)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            //Mettre à jour index selectionner Par rapport au flèches Haut/Bas
            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }
            }
            return keyPressed;
        }
        public int Run()
        {
            ConsoleKey keyPressed = ConsoleKey.F20;
            do
            {
                //Vider la console
                Console.Clear();
                //Rendu du menu
                DisplayOptions();


                keyPressed = Indexation(keyPressed);

            }// Boucle continue tant qu' Enter n'est pas appuyer
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

        }
    }
}
