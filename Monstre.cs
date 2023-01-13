using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsAndDragons
{
    internal class Monstre : Entity
    {
        
        public Monstre(string name,string attaqueElement, int attaquePuissance ,int vie, string resistanceElement, int resistancePourcentage, int niveau) : base(name)
        {
            AttaqueElement = attaqueElement;
            AttaquePuissance = attaquePuissance;
            Vie = vie;
            ResistanceElement= resistanceElement;
            ResistancePourcentage = resistancePourcentage;
            Level = niveau;
            FixeVieMax(Vie);
            Symbole = "*";
        }
        public Monstre(String name) : base(name)
        {
            switch (name)
            {
                case "Gobelin":
                    CreateGobelin();
                    break;
                case "Monstre des marrais":
                    CreateMonstreDesMarrais();
                    break;
                case "Araignée":
                    CreateAraignée();
                    break;
                case "Monstre des bois":
                    CreateMonstreDesBois();
                    break;
                case "Loup garou":
                    CreateLoupGarou();
                    break;
                case "Ogre":
                    CreateOgre();
                    break;
                case "Plante sauvage":
                    CreatePlanteSauvage();
                    break;
                case "Sanglier des ardennes":
                    CreateSanglierDesArdennes();
                    break;
                case "Aigle royal":
                    CreateAigleRoyal();
                    break;
                case "Zombie infecté":
                    CreateZombieInfecté();
                    break;
                case "Sorciere des buissons":
                    CreateSorciereDesBuissons();
                    break;
                case "Dragon de feu":
                    CreateDragonDeFeu();
                    break;
                case "Dragon de glace":
                    CreateDragonDeGlace();
                    break;
                default:
                    Console.WriteLine("Monstre inexistant!");
                    break;
            }
            FixeVieMax(Vie);
        }

        public void CreateGobelin()
        {
            Name = "Gobelin";
            AttaqueElement = "foudre";
            AttaquePuissance = 20;
            Vie = 70;
            ResistanceElement = "feu";
            ResistancePourcentage = 10;
            Level = 2;
            Symbole = "‽";
        }

        public void CreateMonstreDesMarrais()
        {
            Name = "Monstre des marrais";
            AttaqueElement = "eau";
            AttaquePuissance = 30;
            Vie = 90;
            ResistanceElement = "eau";
            ResistancePourcentage = 20;
            Level = 3;
            Symbole = "₪";
        }

        public void CreateAraignée()
        {
            Name = "Monstre des marrais";
            AttaqueElement = "eau";
            AttaquePuissance = 30;
            Vie = 50;
            ResistanceElement = "eau";
            ResistancePourcentage = 20;
            Level = 2;
            Symbole = "₼";
        }

        public void CreateMonstreDesBois()
        {
            Name = "Monstre des bois";
            AttaqueElement = "foudre";
            AttaquePuissance = 17;
            Vie = 80;
            ResistanceElement = "foudre";
            ResistancePourcentage = 10;
            Level = 4;
            Symbole = "Ω";
        }
        public void CreateLoupGarou()
        {
            Name = "Loup Garou";
            AttaqueElement = "feu";
            AttaquePuissance = 25;
            Vie = 90;
            ResistanceElement = "feu";
            ResistancePourcentage = 25;
            Level = 5;
            Symbole = "₢";
        }
        public void CreateOgre()
        {
            Name = "Ogre";
            AttaqueElement = "feu";
            AttaquePuissance = 30;
            Vie = 100;
            ResistanceElement = "feu";
            ResistancePourcentage = 25;
            Level = 5;
            Symbole = "♀";
        }
        public void CreatePlanteSauvage()
        {
            Name = "Plante sauvage";
            AttaqueElement = "eau";
            AttaquePuissance = 25;
            Vie = 75;
            ResistanceElement = "eau";
            ResistancePourcentage = 25;
            Level = 4;
            Symbole = "Ⱡ";
        }
        public void CreateSanglierDesArdennes()
        {
            Name = "Sanglier des Ardennes";
            AttaqueElement = "foudre";
            AttaquePuissance = 25;
            Vie = 85;
            ResistanceElement = "foudre";
            ResistancePourcentage = 25;
            Level = 5;
            Symbole = "∂";
        }
        public void CreateAigleRoyal()
        {
            Name = "Aigle royal";
            AttaqueElement = "eau";
            AttaquePuissance = 18;
            Vie = 78;
            ResistanceElement = "eau";
            ResistancePourcentage = 18;
            Level = 4;
            Symbole = "₮";
        }
        public void CreateZombieInfecté()
        {
            Name = "Zombie infecté";
            AttaqueElement = "feu";
            AttaquePuissance = 35;
            Vie = 90;
            ResistanceElement = "eau";
            ResistancePourcentage = 35;
            Level = 7;
            Symbole = "₽";
        }
        public void CreateSorciereDesBuissons()
        {
            Name = "Sorciere des buissons";
            AttaqueElement = "eau";
            AttaquePuissance = 35;
            Vie = 100;
            ResistanceElement = "feu";
            ResistancePourcentage = 35;
            Level = 7;
            Symbole = "ⱡ";
        }
        public void CreateDragonDeFeu()
        {
            Name = "Dragon de feu";
            AttaqueElement = "feu";
            AttaquePuissance = 40;
            Vie = 140;
            ResistanceElement = "feu";
            ResistancePourcentage = 40;
            Level = 9;
            Symbole = "₴";
        }
        public void CreateDragonDeGlace()
        {
            Name = "Dragon de glace";
            AttaqueElement = "eau";
            AttaquePuissance = 40;
            Vie = 140;
            ResistanceElement = "eau";
            ResistancePourcentage = 40;
            Level = 9;
            Symbole = "₻";
        }
    }
}
