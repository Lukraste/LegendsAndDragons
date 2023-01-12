using System;

namespace LegendsAndDragons
{
    public abstract class Hero : Entity
    {
        public Dictionary<int, string> Inventory {get;set;}
        public Dictionary<int, string> Weapons {get;set;}
        public Dictionary<int, int> Levels {get;set;}
        public int? CurrentLevel {get;set;}
        public int? TotalXP {get;set;}
        public int? Strength {get;set;}
        public int? Intelligence {get;set;}
        public int? Agility {get;set;}      
        public int MaxHitPoints {get;set;}
        public int? Lifes {get;set;}
        
        public Hero(string name) : base(name)
        {
            Name = name;
            Inventory = new Dictionary<int, string>();
            Weapons = new Dictionary<int, string>();
            Levels = new Dictionary<int, int>()
            {
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
        }

        // Gestion des points de vie

        public string GainHP(int hitpoints){
            HitPoints += hitpoints;
            if(HitPoints > MaxHitPoints){
                HitPoints = MaxHitPoints;
            }
            string result = $"{hitpoints} points de vie restauré(s)";
            return result;
        }
        public override void LoseHP(int hitpoints){
            HitPoints -= hitpoints;
            if(HitPoints <= 0){
                Lifes -= 1 ;               
            }
            CheckLifes(hitpoints);
        }
        public string CheckLifes(int hitpoints)
        {
            if(Lifes == 0){
                string result = $"--------> GAME OVER <--------";
                return result;
            }
            else{
                string result = $"Vous avez perdu {hitpoints} points de vie";
                return result;
            }
        }

        public void Attack()
        {
            //
        }

        // Gestion du leveling et de l'experience
        /*
        public string GainXP(int experience){
            TotalXP += experience;
            if(CheckXP()){
                string result = $"Bravo !!! Level {level} atteint !";
                return result;
            }
            else {
                string result = $"{experience} Points d'expérience gagné(s)";
                return result;
            }
        }
        public void CheckXP(){
            return true;
        }
        */
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

        // Affichage des données sur le Héro


        public string ShowWeapons()
        {
            string result = $"Arme principale : {Weapons[0]} \n Arme secondaire : {Weapons[1]}";
            return result;           
        }            
        public void ShowStats() => Console.WriteLine($"Niveau actuel : {CurrentLevel}\nPoints d'expérience : {TotalXP}\nForce : {Strength}\nAgilité : {Agility}\nIntelligence : {Intelligence}\nPoints de vie restants : {HitPoints}\nArmure : {Armor}\nNombre de vies restantes : {Lifes}"); 
    }
}
    