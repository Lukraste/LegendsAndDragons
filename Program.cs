//using Jeu_de_role_POO;
using GameRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace GameRpg
{
    class Game
    {
        static void Main(string[] args)
        {
            //**
            //MENU
            //*
            Console.Title = "Legends and Dragons";
            // Text
            MainMenu.Menu();
            MainMenu.WriteLogo();
            Console.WriteLine("Bienvenue");
            Console.ReadKey(true);

            //**
            //MAPPING
            //**
            //Console.WriteLine("Legends and dragons");
            //Map map = new();
            //map.AfficheMap();

        }
    }
}

