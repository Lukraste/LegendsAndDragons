using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsAndDragons
{
    internal abstract class Entity
    {
        // Propriétés de caractèristiques de l'entité
        public string Name {get; set;}
        public string Description {get;set;}
        public string AttaqueElement {get; set;}
        public int AttaquePuissance {get; set;}
        public int Vie {get; set;}
        public string ResistanceElement {get; set;}
        public int ResistancePourcentage {get; set;}
        public int VieMax {get; private set;}
        public string Symbole {get; set;}

        // Propriétés servant à la phase de combat
        public int DegatSubit {get; set;} = 0;
        public int SoinRecu {get; set;} = 0;

        //Positionnement sur la carte
        private int[] positionSurCarte = new int[2];
        public int WhereNumCarte {get; set;}
        public int WherePos {get; set;}

        //  Status de l'entitée
        protected bool IsDead{get;set;} = false;

        // Constructeur de l'entité
        public Entity(string name)
        {
            Name = name;
        }

        // Attribution de la vie maximale
        public void FixeVieMax(int vie)
        {
            VieMax = vie;
        }
    }
}
