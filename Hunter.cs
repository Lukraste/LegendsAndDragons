using System;

namespace LegendsAndDragons 
{
    public class Hunter : Hero 
    {
        public Hunter(string name) : base(name)
        {
            Name = name;
            Type = "Chasseur";
            Description = "Un chasseur aguérri et abile. Très mobile et forte agilités. Plutôt polyvalent en degats et en points de vie";
            TotalXP = 0;
            Strength = 15;
            Agility = 30;
            Intelligence = 20;
            HitPoints = 110;
            MaxHitPoints = 110;
            Armor = 10;
            Lifes = 3;
        }
        public string Ultimate()
        {
            Strength += 10;
            Agility += 10;
            string result = "Force augmentée de 10 \n Agilité augmentée de 10 \n Pour 3 tours";
            return result;
        }
    }
}