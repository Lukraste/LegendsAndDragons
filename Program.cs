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

        
        //Cette fonction permet de créer une liste d'armures
        // -------------------------------------------------

        var armures = new List<Armor>
        {
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


        // Cette fonction permet de créer une liste d'armes
        var armes = new List<Weapon>()
        {
            new Weapon("Masse de Sauron","Guerrier","Earth","Arme de Sauron laissé derrire lui apres ca defaite ", 50),
            new Weapon("excalibur","Guerrier", "Fire", "Il est pppur les couers vaillant", 30),
            new Weapon("Baguette de Sareau","Sorcier","Water","Cette magie te rendra le plus puissant de ta categorie", 40),
            new Weapon("Le baiser de Diane","Archer", "Thunder", "Cette arc vous donnera la maitrise de Diane", 60) 
        };

        armes = armes.OrderBy( a => a.name).ToList();
        foreach(var arme in armes)
        {
            arme.DisplayWeapon();
        }
    
    }
}
