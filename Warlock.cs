using System;

namespace LegendsAndDragons 
{
    public class Warlock : Hero
    {
        public Warlock(string name) : base(name)
        {
            Name = name;
            Description = "Un ancien mage noir. Points de vie et armure faibles. Dégâts massifs contre les monstres";
            Inventory = new Dictionary<int, string>();
            Weapons = new Dictionary<int, string>();
            Levels = [
                [1, 50],
                [2, 100],
                [3, 150],
                [4, 200],
                [5, 300],
                [6, 400],
                [7, 550],
                [8, 700],
                [9, 750],
                [10, 1000],
                ];
            TotalXP = 0;
            Strength = 30;
            Agility = 15;
            Intelligence = 40;
            HitPoints = 100;
            MaxHitPoints = 100;
            Armor = 10;
            Lifes = 3;
        }

        // Attaque spéciale de la class de héro

        public string Ultimate()
        {
            Intelligence += 20;
            Strength += 10;
            var NbrTours = 3;
            return Console.WriteLine("Intelligence augmentée de 20 \n Force augmentée de 10 \n pour 3 tours");
        }
    }
}


