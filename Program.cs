using System;

namespace LegendsAndDragons
{
    public class Play
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quel est le nom ?");
            string name = Console.ReadLine();
            Knight hero1 = new Knight(name);

            hero.LoseHP(20);
            hero.ShowStats();    
        }
    }
}