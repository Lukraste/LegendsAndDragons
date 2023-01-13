using LegendAndDragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsAndDragons
{
    internal class Hero : Entity
    {
        // Popritétés des caractéristiques du héro
        public string NameClass {get; set;}
        public Weapon HeroWeapon {get;set;}
        public int TotalXP {get;set;}
        public int Lifes {get;set;}
        
        // Constructeur du héro 
        public Hero(string name, string nameClass) : base(name)
        {
            Name = name;
            Lifes = 3;
            Level = 0;
            TotalXP = 0;

            if (nameClass == "Warlock")
                CreateWarlock();
            if (nameClass == "Knight")
                CreateKnight();
            if (nameClass == "Hunter")
                CreateHunter();  

            FixeVieMax(Vie);
            WhereNumCarte = 9;
            WherePos = 3;      
        }

        public void CreateWarlock()
        {   
            NameClass = "Warlock";
            Description = "Un ancien mage noir. Points de vie et armure faibles. Dégâts massifs contre les monstres";
            AttaqueElement = "eau";
            AttaquePuissance = 30;
            Vie = 100;
            ResistanceElement = "eau";
            ResistancePourcentage = 10;
            Symbole = "⌠";
            HeroWeapon = new ("Mage");
        }
        public void CreateKnight()
        {
            NameClass = "Knight";
            Description = "Un chevalier experimenté. Beaucoup de points de vie et résistant. Bon dégats mais aucune agilité";
            AttaqueElement = "terre";
            AttaquePuissance = 50;
            Vie = 130;
            ResistanceElement = "terre";
            ResistancePourcentage = 10;
            Symbole = "ʄ";
            HeroWeapon = new ("Guerrier");
        }
        public void CreateHunter()
        {
            NameClass = "Hunter";
            Description = "Un chasseur aguérri et abile. Très mobile et forte agilités. Plutôt polyvalent en degats et en points de vie";
            AttaqueElement = "feu";
            AttaquePuissance = 40;
            Vie = 110;
            ResistanceElement = "feu";
            ResistancePourcentage = 10;
            Symbole = "ɟ";
            HeroWeapon = new ("Archer");
        }
        
        // Gestion des points de vie

        public string GainHP(int vie){
            Vie += vie;
            if(Vie > MaxVie){
                Vie = MaxVie;
            }
            string result = $"{vie} points de vie restauré(s)";
            return result;
        }

        public override void LoseHP(int vie){
            Vie -= vie;
            if(Vie <= 0){
                Lifes -= 1 ;               
            }
            CheckLifes(vie);
        }

        public string CheckLifes(int hitpoints)
        {
            if(Lifes == 0){
                string result = $"--------> GAME OVER <--------";
                return result;
            }
            else{
                string result = $"Vous avez récupéré {Vie} points de vie";
                return result;
            }
        }

        // Ajout de point d 'experience

        public string GainXP(int experience){
            TotalXP += experience;

            if(TotalXP >= 100)
            {
                Level += 1;
                if(Level == 10)
                {
                    string result = $"--------> GAME FINISHED <--------";
                    return result;
                }
                else
                {
                    TotalXP = 0;
                    string result = $"--------> Vous êtes passé au niveau {Level} <--------";
                    return result;
                }
            }
            return "";
        }

        // Ajouter une arme

        public void AddWeapon(Weapon weapon)
        {
            var index = 1; //Weapon.Count
            index++;
            //Weapon.Add(index, weapon);
        }

        // Affichage des données sur le Héro

        public string ShowWeapons()
        {
            string result = $"Arme principale : {HeroWeapon.Name} \n Arme secondaire : {HeroWeapon.Name}";
            return result;           
        }            
        public void ShowStats()
        {
            Console.WriteLine($"Nom : {Name}\nNiveau actuel : {Level}\nPoints d'expérience : {TotalXP}\nPuissance d'attaque : {AttaquePuissance}Element : {AttaqueElement}\nPoints de vie restants : {Vie}\nNombre de vies restantes : {Lifes}"); 
        } 
    }
}   
    