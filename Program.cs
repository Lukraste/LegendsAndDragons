using System;
using System.Collections.Generic;
using System.Linq;
using ArmorPlayer;
using ChestGame;
namespace MyWeapons; // Note: actual namespace depends on the project name.


class Program
{


    //Partie principal du code 
    static void Main(string[] args)
    {

        
        //Cette fonction permet de créer une liste de lect
        // -------------------------------------------------

        var armures = new List<Armor>{
            new Armor("SansPeur", "Fire",30, "Water"),
            new Armor("PurpleRain","Water",50, "Thunder"),
            new Armor("Fareday", "Thunder", 40, "earth"),
            new Armor( "GroudonTanker", "Earth", 80, "Fire"),
        };

        armures = armures.OrderBy(p => p.name).ToList();
        foreach (var armure in armures)
        {
            armure.DisplayArmor();
        }
    
    }
}
