using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Joueur : Personnage
    {
        
        public string NameClass { get; set; }
        public Arme Weapon { get; set; }
        public int gold { get; set; }


        public Joueur(string namePlayer, string nameClass)
        {
            Name = namePlayer;
            Niveau = 1;
            gold = 0;
            Weapon = new("Gand", "terre",0);
            if (nameClass == "Mage")
                CreateMage();
            if (nameClass == "Knight")
                CreateKnight();
            if (nameClass == "Hunter")
                CreateHunter();
            FixeVieMax(Vie);
            WhereNumCarte = 9;
            WherePos = 3;
        }

        public void EquipeEpee(Arme weapon)
        {
            Weapon = weapon;
        }

        public void CreateMage()
        {
            NameClass = "Mage";
            AttaqueElement = "eau";
            AttaquePuissance = 30;
            Vie = 100;
            ResistanceElement = "eau";
            ResistancePourcentage = 10;
            Symbole = "⌠";
        }
        public void CreateKnight()
        {
            NameClass = "Knight";
            AttaqueElement = "terre";
            AttaquePuissance = 50;
            Vie = 130;
            ResistanceElement = "terre";
            ResistancePourcentage = 10;
            Symbole = "ʄ";
        }
        public void CreateHunter()
        {
            NameClass = "Hunter";
            AttaqueElement = "feu";
            AttaquePuissance = 40;
            Vie = 110;
            ResistanceElement = "feu";
            ResistancePourcentage = 10;
            Symbole = "ɟ";
        }
    }
}
