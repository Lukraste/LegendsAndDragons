using GameProject;
using LegendsAndDragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Permet de ne plus utiliser Console.
//using static System.Console;





namespace LegendsAndDragons
{
    class Program
    {
        static void Main(string[] args)
        {
            //**
            //MENU
            //*
            //Console.Title = "Legends and Dragons";
            //// Text
            //Menu.MainMenu();
            //Menu.WriteLogo();
            //Console.WriteLine("Bienvenue");
            //Console.ReadKey(true);



            //TEST Animations
            //Console.Title = "test";

            //Console.WriteLine("Hello");
            //Thread.Sleep(1000);
            //Console.WriteLine("Goodbye");



            //Animations clignotante top gauche
            //            Animations.Blink(@"  ___ ___         .__  .__          
            // /   |   \   ____ |  | |  |   ____  
            ///    ~    \_/ __ \|  | |  |  /  _ \ 
            //\    Y    /\  ___/|  |_|  |_(  <_> )
            // \___|_  /  \___  >____/____/\____/ 
            //       \/       \/                  ",
            //            5, 1000, 100);




            //string programmingQuote = @"Lorem ipsum dolor sit amet, 
            //consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore 
            //magna aliqua. Bibendum est ultricies integer quis auctor. Pellentesque nec nam aliquam sem et tortor consequat. Nisl vel pretium lectus quam id. Integer enim neque volutpat ac tincidunt. Consectetur adipiscing elit ut aliquam purus. Sed egestas egestas fringilla phasellus faucibus. Tincidunt vitae semper quis lectus nulla at volutpat. Amet venenatis urna cursus eget nunc. Id aliquet lectus proin nibh nisl condimentum id venenatis a. Facilisis volutpat est velit egestas dui id ornare arcu. Interdum consectetur libero id faucibus nisl tincidunt. Eu turpis egestas pretium aenean pharetra magna ac. Volutpat odio facilisis mauris sit. Lectus sit amet est placerat. Diam ut venenatis tellus in metus. Ut morbi tincidunt augue interdum velit euismod in pellentesque.
            //";

            //Animations.Typing(programmingQuote, 3);

            //string[] frames = { "(o_o)", "(O_o)", "(O_O)", "(o_O)" };
            //string[] frames = { "(>)", "(v)", "(<)", "(^)" };
            //Animations.Frames(frames, 1, 50);


            //Console.WriteLine("\n Appuyer un touche pour quitter");
            //Console.ReadKey(true);


            //Menu interactif code fonctionnel
            Game myGame = new Game();
            myGame.Start();






            //**
            //MAPPING
            //**
            //Console.WriteLine("Legends and dragons");

            //Map map = new();
            //map.AfficheMap();
        }
    }
}


