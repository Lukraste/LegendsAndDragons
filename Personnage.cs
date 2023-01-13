using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal abstract class Personnage
    {
        public string Name { get; set; }
        public string AttaqueElement { get; set; }
        public int AttaquePuissance { get; set; }
        public int Vie { get; set; }
        public string ResistanceElement { get; set; }
        public int ResistancePourcentage { get; set; }
        public int Niveau { get; set; }

        private int[] positionSurCarte = new int[2];
        public int DegatSubit { get; set; } = 0;
        public int SoinRecu { get; set; } = 0;
        public int VieMax { get; private set; }
        public string Symbole { get; set; }
        public int WhereNumCarte { get; set; }
        public int WherePos { get; set; }

        //Methode
        public void FixeVieMax(int vie)
        {
            VieMax = vie;
        }
        

    }
    
}
