using System;
using System.Collections.Generic;
using System.Text;

// FormationCS.outils.DemanderNombreEntre

namespace ArmorPlayer
{

    class Armor
    {
        public string name { get; set; }
        public string type {get; set; }      
        public int defence { get; set; }
        public string weakness { get; set; }

        public Armor(string name, string type, int defence, string weakness)
        {
          
            this.name = name;
            this.type = type;
            this.defence = defence;
            this.weakness = weakness;

        }

        public void DisplayArmor(){

            Console.WriteLine("Nom de l'armure : " + name );
            Console.WriteLine("Type de l'armure : " + type );
            Console.WriteLine("Defence : " + defence );
            Console.WriteLine("Faiblesse de l'armure : " + weakness );

        }



    }




    class Weapon
    {
        private string name;
        private string classe;
        private string type;
        private string description;
        private int damage;

        // Valeurs par defaut des armes 
        public Weapon()
        {
            name = "HeadReaper";
            classe = "Foudre";
            type = "Arme";
            description = "Ideal pour faire tomber les tete de nos enemis";
            damage = 10;
        }

        public void createWeaponDictionary()
        {
            Dictionary<string,int> weaponList = new Dictionary<string, int>();
        }

        // Constructor of the Weapon class
        public Weapon(string name, string classe,string type, string description, int damage)
        {
            this.name = name;
            this.classe = classe; 
            this.type = type;
            this.description = description;
            this.damage = damage;
        } 


        //print method weapon
        public void printWeapon()
        {
            Console.WriteLine("{0}, {1}, {2},{3},{4}.", name, classe, type, description, damage);
        }

        


    }
}