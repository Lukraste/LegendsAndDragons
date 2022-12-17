using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Arene
    {
        public int Round { get; set; }
        public Joueur Combatant_1 { get; set; }
        public Monstre Combatant_2 { get; set; }
        public int TourAttaquant { get; set; }
        public bool FinDeCombat { get; set; }

        

        public void DesignerPremierAttaquant() 
        {
            Random rnd = new Random();
            TourAttaquant = rnd.Next(1, 3);
        }

        public void Combater()
        { 
            if (TourAttaquant == 1)
            {
                
            }
        }
        public void Affiche() 
        {
            Console.WriteLine("Arene de combat ");
            
        }
        


    }
}
