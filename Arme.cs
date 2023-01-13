using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsAndDragons
{
    internal class Arme
    {
        public string Name { get; set; }
        public string AttaqueElement { get; set; }
        public int AttaquePuissance { get; set; }

        public Arme(string name, string attaqueElement, int attaquePuissance) 
        {
            Name = name;
            AttaqueElement = attaqueElement;
            AttaquePuissance = attaquePuissance;
        }

        public Arme(string name)
        {
            AttaquePuissance = 10;
            if (name.Equals("Epee"))
                createEpee();
            if (name.Equals("Baquette"))
                createBaquette();
            if (name.Equals("Arc"))
                createArc();
        }

        public void createEpee()
        {
            Name = "Epée";
            AttaqueElement = "terre";   
        }
        public void createBaquette()
        {
            Name = "Baquette";
            AttaqueElement = "eau";
        }
        public void createArc()
        {
            Name = "Arc";
            AttaqueElement = "feu";
        }
    }
}
