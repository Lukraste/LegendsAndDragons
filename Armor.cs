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
        public string name;
        public string classe;
        public string type;
        public string description;
        public int damage;


        public Weapon(string name, string classe, string type, string description, int damage)
        {
            this.name = name;
            this.classe = classe;
            this.type = type;
            this.description = description;
            this.damage = damage;
        }


        // Valeurs par defaut des armes 
        public void BasicWeapon()
        {
            name = "HeadReaper";
            classe = "Foudre";
            type = "Arme";
            description = "Ideal pour faire tomber les tete de nos enemis";
            damage = 10;
        }

         public void DisplayWeapon(){

            Console.WriteLine("Nom de l'arme : " + name );
            Console.WriteLine("Classe de l'arme : " + classe );
            Console.WriteLine("Type de l'arme : " + type );
            Console.WriteLine("Attaque : " + damage );
            Console.WriteLine("Description : " + description );

        }
       
        


    }
}