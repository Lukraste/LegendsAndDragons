using System;

namespace LegendsAndDragons 
{
    public class Warlock : Hero
    {
        public Warlock(string name) : base(name)
        {
            Name = name;
            Type = "Mage noir";
            Description = "Un ancien mage noir. Points de vie et armure faibles. Dégâts massifs contre les monstres";
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
            string result = "Intelligence augmentée de 20 \n Force augmentée de 10 \n pour 3 tours";
            return result;
        }
    }
}


