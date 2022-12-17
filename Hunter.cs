using System;

namespace LegendsAndDragons 
{
    public class Hunter : Hero
    {
        public Hunter(string name) : base(name)
        {
            this.Name = "Hunter";
            this.Description = "Un chasseur aguérri et abile. Très mobile et forte agilités. Plutôt polyvalent en degats et en points de vie";
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
            Strength = 15;
            Agility = 30;
            Intelligence = 20
            HitPoints = 110;
            MaxHitPoints = 110;
            Armor = 10;
            Lifes = 3;
        }
        public string ArrowsRain()
        {
            Strength += 10;
            Agility += 10;
            var NbrTours = 3;
            return Console.WriteLine("Force augmentée de 10 \n Agilité augmentée de 10 \n pour 3 tours");
        }
    }
}