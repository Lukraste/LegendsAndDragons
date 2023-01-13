using System;
using System.Collections.Generic;


namespace LegendAndDragons{

    class BodyShield
    {
        public string name { get; set; }
        public string element { get; set; }
        public int defence { get; set; }
        public string weakness { get; set; }

        public BodyShield(string name, string element, int defence, string weakness)
        {
            this.name = name;
            this.element = element;
            this.defence = defence;
            this.weakness = weakness;
        }

        public void DisplayArmor(){

            Console.WriteLine("Nom de l'armure : " + name );
            Console.WriteLine("Type de l'armure : " + element );
            Console.WriteLine("Defence : " + defence );
            Console.WriteLine("Faiblesse de l'armure : " + weakness );
            
        }
    }
}