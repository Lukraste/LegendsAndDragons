using System;

namespace LegendsAndDragons
{
    public class Play
    {
        static void Main(string[] args)
        {
            Knight hero = new Knight("Lancelot");
            hero.LoseHP(20);
            hero.ShowStats();    
        }
    }
}