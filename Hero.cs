using System;

namespace LegendsAndDragons
{
    public abstract class Hero
    {
        protected string Name {get;set;}
        protected string Description {get;}
        protected Dictionary<int, string> Inventory {get;set;}
        protected Dictionary<int, string> Weapons {get;set;}
        protected Dictionary<int, int> levels {get;set;}
        protected int TotalXP {get;set;}
        protected int Strength {get;set;}
        protected int Agility {get;set;}
        protected int Armor {get;set;}
        protected int HitPoints {get;set;}
        protected const int MaxHitPoints = 100;
        protected int Lifes {get;set;}
        protected int Intelligence {get;set;}

        // Gestion des points de vie

        public string GainHP(int hitpoints){
            HitPoints += hitpoints;
            if(HitPoints > MaxHitPoints){
                HitPoints = MaxHitPoints;
            }
            return Console.WriteLine($"{hitpoints} points de vie restauré(s)");
        }
        public string LoseHP(int hitpoints){
            HitPoints -= hitpoints;
            if(HitPoints <= 0){
                Lifes -= 1 ;               
            }
            if(checkLifes()){
                return Console.WriteLine("--------> GAME OVER <--------");
            }
            else{
                return Console.WriteLine($"Vous avez perdu {hitpoints} points de vie");
            }
        }
        public bool CheckHP(){
            if(Lifes == 0){
                return true;
            }
            else {
                return false;
            }
        }

        // Gestion du leveling et de l'experience

        public string GainXP(int experience){
            XP += experience;
            if(checkXP()){
                return Console.WriteLine($"Bravo !!! Level {level} atteint !");
            }
            else {
                return Console.WriteLine($"{experience} points d'expérience gagné(s)");
            }
        }
        public bool checkXP(){
            
        }

        // Gestion de l'inventaire et des armes


        public void AddWeapon(string weapon)
        {
            var index = Weapons.Count;
            index++;
            Weapons.Add(index, weapon);
        }
        public void AddItem(string item)
        {
            var index = Inventory.Count;
            index++;
            Inventory.Add(index, item);
        }
        public string ShowWeapons()
        {
            return Console.WriteLine($"Arme principale : {Weapons[0]} \n Arme secondaire : {Weapons[1]}");           
        }

        public string ShowStats()
        {
            return Console.WriteLine($"Arme principale : {Weapons} \n Arme secondaire : {Weapons[1]}");           
        }
    }
}
    