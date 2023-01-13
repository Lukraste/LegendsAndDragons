using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FormationCS.outils.DemanderNombreEntre

namespace LegendAndDragons
{

    class Weapon
    {
        public string name;
        public string classe;
        public string element;
        public string description;
        public int damage;


        public Weapon(string name, string classe, string element, string description, int damage)
        {
            this.name = name;
            this.classe = classe;
            this.element = element;
            this.description = description;
            this.damage = damage;
        }


        public void HeroWeapon(string name)
        {
            if (classe == "Guerrier"){
                CreateSword();
            }
            else if (classe == "Mage"){
                CreateWizard();
            }
            else if (classe == "Archer"){
                CreateHunter();
            }
            

        }

        public void CreateSword()
        {
            name = "HeadReaper";
            classe = "Guerrier";
            element = "foudre";
            description = "Ideal pour faire tomber les tete de nos enemis";
            damage = 10;
        }

        public void CreateWizard(){
            name = "natsuDragniel";
            classe = "Sorcier";
            element = "feu";
            description = "un esprit calme avec un coeur hardant";
            damage = 13;
        }

        public void CreateHunter(){
            name = "fateStayNight";
            classe = "Archer";
            element = "Eau";
            description = "Seul une main puissante et un soufle calme meneront à votre cible";
            damage = 8;
        }
        // Valeurs par defaut des armes 
        

         public void DisplayWeapon(){

            Console.WriteLine("Nom de l'arme : " + name );
            Console.WriteLine("Classe de l'arme : " + classe );
            Console.WriteLine("Type de l'arme : " + element );
            Console.WriteLine("Attaque : " + damage );
            Console.WriteLine("Description : " + description );

        }
    }
}
