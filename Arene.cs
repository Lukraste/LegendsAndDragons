
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    internal class Arene
    {
        public int Round { get; set; }
        public Personnage[] Combattants { get; set; } = new Personnage[2];
        public int TourAttaquant { get; set; }
        public int TourDefenseur { get; set; }
        public bool FinDeCombat { get; set; }




        public void ajouteCombatants(Joueur joueur, Monstre monstre)
        {
            Combattants[0] = joueur;
            Combattants[1] = monstre;
            Round = 1;
            FinDeCombat = false;
            DesignerPremierAttaquantEtDefenseur();
        }

        public void DesignerPremierAttaquantEtDefenseur()
        {
            Random rnd = new Random();
            TourAttaquant = rnd.Next(1, 3);
            if (TourAttaquant == 1)
                TourDefenseur = 2;
            else
                TourDefenseur = 1;

        }
        public void ChangerAttaquantEtDefenseur()
        {
            if (TourAttaquant == 1)
            {
                TourAttaquant = 2;
                TourDefenseur = 1;
            }

            else
            {
                TourAttaquant = 1;
                TourDefenseur = 2;
            }

        }

        public void Combater()
        {
            //Calcul dégats subit
            if (Combattants[TourDefenseur - 1].ResistanceElement.Equals(Combattants[TourAttaquant - 1].AttaqueElement))
            {
                Combattants[TourDefenseur - 1].DegatSubit = (Int32)(Combattants[TourAttaquant - 1].AttaquePuissance * (100 - Combattants[TourDefenseur - 1].ResistancePourcentage) / 100);
            }
            else
            {
                Combattants[TourDefenseur - 1].DegatSubit = (Combattants[TourAttaquant - 1].AttaquePuissance);
            }
        }
        public void AfficheRoundDebut()
        {
            String[] choixActionCombat = { "Atttaquer", "Se soigner", "S'enfuir" };
            Menu menuCombat = new("Que veux-tu faire?", choixActionCombat);
            ConsoleKey pressedKey = ConsoleKey.F20;
            do
            {
                Console.Clear();
                Console.WriteLine("Arene de combat : Round " + Round);
                Console.WriteLine("Combattant : " + ((Joueur)Combattants[0]).NameClass + " " + Combattants[0].Name + " VS " + Combattants[1].Name + "\n");
                Console.WriteLine("Vie Joueur : " + Combattants[0].Vie + "\t\t" + " --- " + "\t\t" + "Vie Monstre : " + Combattants[1].Vie);
                AfficheGraphismeCombatGeneral();
                Console.WriteLine("Element d'attaque : " + Combattants[0].AttaqueElement + "\t\t" + " --- " + "\t\t" + Combattants[1].AttaqueElement);
                Console.WriteLine("Puissance d'attaque: " + Combattants[0].AttaquePuissance + "\t\t\t" + " --- " + "\t\t" + Combattants[1].AttaquePuissance);
                Console.WriteLine("Element de défence: " + Combattants[0].ResistanceElement + "\t\t" + " --- " + "\t\t" + Combattants[1].ResistanceElement);
                Console.WriteLine("Resistance défence: " + Combattants[0].ResistancePourcentage + "%" + "\t\t\t" + " --- " + "\t\t" + Combattants[1].ResistancePourcentage + "%");
                Console.WriteLine("Nom Arme: " + ((Joueur)Combattants[0]).Weapon.Name);
                Console.WriteLine("Element Arme: " + ((Joueur)Combattants[0]).Weapon.AttaqueElement);
                Console.WriteLine("Puissance Arme: " + ((Joueur)Combattants[0]).Weapon.AttaquePuissance);
                Console.WriteLine();
                Console.WriteLine("Personnage qui va attaquer maintenant : " + Combattants[TourAttaquant - 1].Name);
                menuCombat.DisplayOptions();
                //menuCombat.LectureEtTraitementClavier();
                pressedKey = menuCombat.Indexation(pressedKey);
                int choixCombattant = -1;
                if (pressedKey == ConsoleKey.Enter)
                {
                    choixCombattant = menuCombat.SelectedIndex;
                }
                switch (choixCombattant)
                {
                    case 0:     //attaquer
                        Combater();
                        if (Combattants[TourAttaquant - 1].Name.Equals(Combattants[0].Name))
                        {
                            AfficheGraphismeCombatJoueurAttaque();
                        }
                        else
                        {
                            AfficheGraphismeCombatMonstreAttaque();
                        }
                        break;
                    case 1:     //se soigner
                        Soigner();
                        AfficheGraphismeCombatSoigner();
                        break;
                    case 2:     //s'enfuir
                        FinDeCombat = true;
                        break;
                    default:
                        break;
                }
                Round++;
                ChangerAttaquantEtDefenseur();
                if (Combattants[0].Vie <= 0 || Combattants[1].Vie <= 0)
                {
                    FinDeCombat = true;
                }
                if (Combattants[0].Vie > Combattants[0].VieMax)
                {
                    Combattants[0].Vie = Combattants[0].VieMax;
                }
                if (Combattants[1].Vie > Combattants[1].VieMax)
                {
                    Combattants[1].Vie = Combattants[1].VieMax;
                }
            } while (pressedKey != ConsoleKey.Enter);

        }
        public void AfficheRoundFin()
        {
            Console.Clear();
            if (Combattants[0].Vie <= 0)
            {
                Console.WriteLine("\n\tGAME OVER \n Vous n'avez malheureusement pas survécu!!");
            }
            if (Combattants[1].Vie <= 0)
            {
                Console.WriteLine("\n\tFELICITATIONS \n Vous avez vaincu : " + Combattants[1].Name + "!!");
                Combattants[0].Vie = Combattants[0].VieMax;
            }
            if (Combattants[0].Vie > 0 && Combattants[1].Vie > 0)
            {
                Console.WriteLine("\n\tTROUILLARD \n Vous vous êtes enfuis!!");
                Combattants[1].Vie = Combattants[1].VieMax;
            }
            Console.ReadKey();

        }
        public void Soigner()
        {
            Random rnd = new Random();
            Combattants[0].SoinRecu += rnd.Next(1, 10) * Combattants[0].Niveau;
            Combattants[1].SoinRecu += rnd.Next(1, 50);
        }

        public void AfficheGraphismeCombatGeneral()
        {
            Console.WriteLine(@"    
                ___               |       _   _
               /   \              |       |\_/|
              |( °}°\                    o o  )
              __|  |_   --              <____ )
             <       > //             +~~~~    )
             |\( ) |                  +~~~      \
               <<-->>                    <<<<<<||
               || ||              |      \   \  |
               <__-__>            |      <___<__|
            ");

        }
        public void AfficheGraphismeCombatJoueurAttaque()
        {
            Console.Clear();
            Console.WriteLine("Arene de combat : Round " + Round);
            Console.WriteLine("Combattant : " + ((Joueur)Combattants[0]).NameClass + " " + Combattants[0].Name + " VS " + Combattants[1].Name + "\n");
            Console.WriteLine("Vie Joueur : " + Combattants[0].Vie + "\t\t" + " --- " + "\t\t" + "Vie Monstre : " + Combattants[1].Vie);
            Console.WriteLine(@"    
                   ___            |       _   _
                  /   \           |       |\_/|
                 |( ^}^\                 x x  )
                 __|  |_    --     \    <   ^ )
                <       >  //  -- \ \ +~~      )
                |\( ) |  __/   -- / /  +~~      \
                  <<-->>           /     <<<<<<||
                  || ||           |      \   \  |
                  <__-__>         |      <___<__|
            ");
            Console.WriteLine("Yes!!!\n");
            Console.Write("Après votre attaque, " + Combattants[1].Name + " a perdu : ");
            Console.WriteLine(Combattants[1].DegatSubit + " points de vie");
            Combattants[1].Vie -= Combattants[1].DegatSubit;
            Console.ReadKey();

        }
        public void AfficheGraphismeCombatMonstreAttaque()
        {
            Console.Clear();
            Console.WriteLine("Arene de combat : Round " + Round);
            Console.WriteLine("Combattant : " + ((Joueur)Combattants[0]).NameClass + " " + Combattants[0].Name + " VS " + Combattants[1].Name + "\n");
            Console.WriteLine("Vie Joueur : " + Combattants[0].Vie + "\t\t" + " --- " + "\t\t" + "Vie Monstre : " + Combattants[1].Vie);
            Console.WriteLine(@"    
                ___               |       _   _
               /   \              |       |\_/|
              |( x x\                    o o  )
              __| ^|_   --              <____ )
             <       > //    +~~~~~~~~~~~~~~    )
             |\( ) |       +~~~~~~~~~~~~~~      \
               <<-->>                    <<<<<<||
               || ||              |      \   \  |
               <__-__>            |      <___<__|
            ");
            Console.WriteLine("No!!!\n");
            Console.Write("Après l'attaque de " + Combattants[1].Name + ", vous avez perdu : ");
            Console.WriteLine(Combattants[0].DegatSubit + " points de vie");
            Combattants[0].Vie -= Combattants[0].DegatSubit;
            Console.ReadKey();
        }

        public void AfficheGraphismeCombatSoigner()
        {
            Console.Clear();
            Console.WriteLine("Arene de combat : Round " + Round);
            Console.WriteLine("Combattant : " + ((Joueur)Combattants[0]).NameClass + " " + Combattants[0].Name + " VS " + Combattants[1].Name + "\n");
            Console.WriteLine("Vie Joueur : " + Combattants[0].Vie + "\t\t" + " --- " + "\t\t" + "Vie Monstre : " + Combattants[1].Vie);
            Console.WriteLine(@"    
                  ___             |       _   _
                 /   \            |       |\_/|
                |('^}^\         _  _     ^ ^' )
                __|  |_    --  ( '' )   <   _ )
               <       >  //    \  /  +~~      )
               |\( ) |           \/  +~~      \
                 <<-->>                 <<<<<<||
                 || ||            |     \   \  |
                 <__-__>          |     <___<__|
            ");
            Console.WriteLine("Cool!!!\n");
            Console.WriteLine("Vous vous etes soinger de : " + Combattants[0].SoinRecu + " points de vie.\n");
            Console.Write("Mais " + Combattants[1].Name + " profite aussi pour se soigner aussi de : ");
            Console.WriteLine(Combattants[1].SoinRecu + " points de vie");
            Combattants[0].Vie += Combattants[0].SoinRecu;
            Combattants[1].Vie += Combattants[1].SoinRecu;
            Console.ReadKey();
        }



    }
}
