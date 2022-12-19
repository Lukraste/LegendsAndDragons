using System;

namespace LegendsAndDragons 
{
    public class Knight : Hero
    {
        public Knight(string name) : base(name)
        {
            Name = name;
            Type = "Chevalier";
            Description = "Un chevalier experimenté. Beaucoup de points de vie et résistant. Bon dégats mais aucune agilité";
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
            string result = "Force augmentée de 15 \n Points de vie augmentés de 20 \n pour 3 tours";
            return result;
        }
    }
}
