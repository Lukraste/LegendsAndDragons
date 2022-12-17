using System;

namespace LegendsAndDragons 
{
    public class Knight : Hero
    {
        public Knight(string name) : base(name)
        {
            this.Name = "Knight";
            this.Description = "Un chevalier experimenté. Beaucoup de points de vie et résistant. Bon dégats mais aucune agilité";
            Inventory = new Dictionary<int, string>();
            Weapons = new Dictionary<int, string>();
            Levels = new Dictionary<int, string>() {
                {1, 50},
                {2, 100},
                {3, 150},
                {4, 200},
                {5, 300},
                {6, 400},
                {7, 550},
                {8, 700},
                {9, 750},
                {10, 1000},
                };
            TotalXP = 0;
            Strength = 20;
            Agility = 10;
            Intelligence = 10;
            HitPoints = 130;
            MaxHitPoints = 130;
            Armor = 20;
            Lifes = 3;
        }
        public string Ultimate()
        {
            HitPoints += 20;
            MaxHitPoints += 20;
            Strength += 15;
            var NbrTours = 3;
            return Console.WriteLine("Force augmentée de 15 \n Points de vie augmentés de 20 \n pour 3 tours");
        }
    }
}
