﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameRpg
{
    class Game
    {
        public void Start()
        {

            Console.Title = "Legends and dragons";
            RunMainMenu();


        }
        private void RunMainMenu()
        {
            string prompt = @"

              _                               _                        _        _                                 
 | |                             | |                      | |      | |                                
 | |     ___  __ _  ___ _ __   __| |___     __ _ _ __   __| |    __| |_ __ __ _  __ _  ___  _ __  ___ 
 | |    / _ \/ _` |/ _ \ '_ \ / _` / __|   / _` | '_ \ / _` |   / _` | '__/ _` |/ _` |/ _ \| '_ \/ __|
 | |___|  __/ (_| |  __/ | | | (_| \__ \  | (_| | | | | (_| |  | (_| | | | (_| | (_| | (_) | | | \__ \
 |______\___|\__, |\___|_| |_|\__,_|___/   \__,_|_| |_|\__,_|   \__,_|_|  \__,_|\__, |\___/|_| |_|___/
              __/ |                                                              __/ |                
             |___/                                                              |___/                           

Bienvenu";



            string[] options = { "Nouvelle partie", "Inventaire","Quitter le jeux" };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            //Dependant l'index sélectionner on execute les méthodes
            switch(selectedIndex)
            {
                case 0:
                    NewGame();
                    break;
                case 1:
                    Inventory();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        
        private void NewGame()

        {
            Console.Clear();
            string prompt = "Sélectionner votre personnage ?";
            string[] options = { "Mage", "Knight", "Hunter", "Warlock", "Necromancer", "Elementalist", "Guardian" };
            Menu CharachterMenu = new Menu(prompt, options);
            int selectedIndex = CharachterMenu.Run();
            
            switch (selectedIndex)
            {
                case 0:
                    Mage();
                    break;
                case 1:
                    Knight();
                    break;
                case 2:
                    Hunter();
                    break; 
                case 3:
                    Warlock();
                    break;
                case 4:
                    Necromancer();
                    break;
                case 5:
                    Elementalist();
                    break;
                case 6:
                    Guardian();
                    break;


            }

            Console.WriteLine("\n Menu choisir perso + Lancer la game (map)");
            Console.ReadKey(true);
            RunMainMenu();

        }

        private void Inventory()
        {
            Console.Clear();
            Console.WriteLine("\n Inventaire a importer");
            Console.ReadKey(true);
            RunMainMenu();

        }
        private void ExitGame()
        {
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void Mage()
        {

        }
        private void Knight()
        {

        }
        private void Hunter()
        {

        }
        private void Warlock()
        {

        }
        private void Necromancer()
        {

        }
        private void Elementalist()
        {

        }
        private void Guardian()
        {

        }


    }
}