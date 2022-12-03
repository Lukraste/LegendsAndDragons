using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Map
    {
        List<string[]> monde= new List<string[]> ();        
        public Map()
        {
            MapConstruct();
        }

        public void MapConstruct() 
        {
            AddCarteMonde("┌", "─", "┐");
            for (int i=0; i < 20; i++) 
            {
                AddCarteMonde("│", " ", "│");
            }
            AddCarteMonde("└", "─", "┘");
        }
        public void AddCarteMonde(string c1, string c2, string c3) 
        {
            string[] carte = new string[80];
            carte[0] = c1;
            for (int i = 1; i < carte.Length - 1; i++)
            {
                carte[i] = c2;
            }
            carte[carte.Length - 1] = c3;
            monde.Add(carte);

        }
        public void AfficheMap()
        {
            foreach (String[] carte in  monde)
            {
                for(int i = 0; i < carte.Length; i++)
                {
                    Console.Write(carte[i]);
                }
            }
        }

    }
}
