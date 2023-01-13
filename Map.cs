using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LegendsAndDragons
{
    internal class Map
    {
        private List<string[]> monde= new List<string[]> ();
        private List<int> passage = new List<int> {8,9,10,11,12};
        private List<int[]> feuilleArbre = new List<int[]>();
        private List<int[]> tronArbre = new List<int[]>();
        private List<int[]> frontMountain = new List<int[]>();
        private List<int[]> platMountain = new List<int[]>();
        private List<int[]> backMountain = new List<int[]>();
        private List<int[]> feuilleLac = new List<int[]>();
        private List<int[]> tronLac = new List<int[]>();
        private List<int[]> smoothFrontLac = new List<int[]>();
        private List<int[]> smoothBackLac = new List<int[]>();
        private List<int[]> sharpFrontLac = new List<int[]>();
        private List<int[]> sharpBackLac = new List<int[]>();
        private List<int[]> shadowLac = new List<int[]>();
        private List<int[]> flatLac = new List<int[]>();
        private List<int[]> fishLac = new List<int[]>();
        private List<int[]> tronCimtery = new List<int[]>();
        private List<int[]> flatCimtery = new List<int[]>();
        private List<int[]> shadowCimtery = new List<int[]>();
        private List<int[]> feuilleVillage = new List<int[]>();
        private List<int[]> tronVillage = new List<int[]>();
        private List<int[]> flatVillage = new List<int[]>();
        private List<int[]> briqueVillage = new List<int[]>();
        private List<int[]> sharpFrontVillage = new List<int[]>();
        private List<int[]> sharpBackVillage = new List<int[]>();
        private List<int[]> buissonVillage = new List<int[]>();
        private List<int[]> fenetreVillage = new List<int[]>();
        private int[] zoneForetNordLimitMin = {1,21};
        private int[] zoneForetNordLimitMax = {7,39};
        private int[] zonePlaineNordLimitMin = { 1, 41 };
        private int[] zonePlaineNordLimitMax = { 7, 59 };
        private int[] zoneMontagneNordLimitMin = { 1, 61 };
        private int[] zoneMontagneNordLimitMax = { 7, 77 };
        private int[] zoneCheminLimitMin = { 8, 1 };
        private int[] zoneCheminLimitMax = { 12, 77 };
        private int[] zoneLacLimitMin = { 13, 1 };
        private int[] zoneLacLimitMax = { 20, 19 };
        private int[] zoneMontagneSudLimitMin = { 13, 21 };
        private int[] zoneMontagneSudLimitMax = { 20, 39};
        private int[] zonePlaineSudLimitMin = { 13, 41 };
        private int[] zonePlaineSudLimitMax = { 20, 59 };
        private int[] zoneForetSudLimitMin = { 13, 61 };
        private int[] zoneForetSudLimitMax = { 20, 77 };
        private List<Monstre> groupeMonstresForetNordMap;      //Zone 1 : Foret maudite du nord
        private List<Monstre> groupeMonstresPlaineNordMap;     //Zone 2 : Plaine cachée du nord
        private List<Monstre> groupeMonstresMontagneNordMap;   //Zone 3 : Montagne sacrée du nord
        private List<Monstre> groupeMonstresCheminCentralMap;     //Zone 4 : Chemin du voyageur
        private List<Monstre> groupeMonstresLacMap;        //Zone 5 : Lac enchantée
        private List<Monstre> groupeMonstresMontagneSudMap;   //Zone 6: Montagne sacrée du sud
        private List<Monstre> groupeMonstresPlaineSudMap;     //Zone 7: Plaine cachée du sud
        private List<Monstre> groupeMonstresForetSudMap;      //Zone 8: Foret maudite du sud
        private Joueur joueurMap;
        public ConsoleKey PressedKeyMap { get; set; }
        private int height = 20;
        public Monstre MonstreChallengeur { get; set; }


        //Constructeur
        public Map(List<Monstre> grpMonstresForetNord, List<Monstre> grpMonstresPlaineNord,
                List<Monstre> grpMonstresMontagneNord, List<Monstre> grpMonstresCheminCentral,
                List<Monstre> grpMonstresLac, List<Monstre> grpMonstresForetSud, 
                List<Monstre> grpMonstresPlaineSud, List<Monstre> grpMonstresMontagneSud, Joueur joueur)
        {
            groupeMonstresForetNordMap = grpMonstresForetNord;
            groupeMonstresPlaineNordMap = grpMonstresPlaineNord;
            groupeMonstresMontagneNordMap = grpMonstresMontagneNord;
            groupeMonstresCheminCentralMap = grpMonstresCheminCentral;
            groupeMonstresLacMap = grpMonstresLac;
            groupeMonstresForetSudMap = grpMonstresForetSud;
            groupeMonstresPlaineSudMap = grpMonstresPlaineSud;
            groupeMonstresMontagneSudMap = grpMonstresMontagneSud;
            joueurMap = joueur;
            BuildTree();
            BuildMountain();
            BuildLac();
            BuildCimtery();
            BuildVillage();
            MapConstruct();
            BuildMonsters();
            AddMonstresSurMap(groupeMonstresCheminCentralMap);
            AddMonstresSurMap(groupeMonstresForetNordMap);
            AddMonstresSurMap(groupeMonstresForetSudMap);
            AddMonstresSurMap(groupeMonstresLacMap);
            AddMonstresSurMap(groupeMonstresMontagneNordMap);
            AddMonstresSurMap(groupeMonstresMontagneSudMap);
            AddMonstresSurMap(groupeMonstresPlaineNordMap);
            AddMonstresSurMap(groupeMonstresPlaineSudMap);
            PressedKeyMap = ConsoleKey.F20;
        }
        
        public void MapConstruct() 
        {
            AddCarteMonde("┌", "─", "┐");
            for (int i=0; i < height; i++) 
            {
                AddCarteMonde("│", " ", "│");
            }
            AddCarteMonde("└", "─", "┘");
            // placement arbre sur map zone 1 nord
            AddElementDecorSurMap(feuilleArbre, "#", 1, 0);
            AddElementDecorSurMap(tronArbre, "|", 1, 0);
            // placement arbre sur map zone 3 sud
            AddElementDecorSurMap(feuilleArbre, "#", 3, 1);
            AddElementDecorSurMap(tronArbre, "|", 3, 1);
            // placement arbre sur map zone 3 nord
            AddElementDecorSurMap(frontMountain, "/", 3, 0);
            AddElementDecorSurMap(platMountain, "_", 3, 0);
            AddElementDecorSurMap(backMountain, "\\", 3, 0);
            // placement montagne sur map zone 1 sud
            AddElementDecorSurMap(frontMountain, "/", 1, 1);
            AddElementDecorSurMap(platMountain, "_", 1, 1);
            AddElementDecorSurMap(backMountain, "\\", 1, 1);
            // placement lac sur map zone 0 sud
            AddElementDecorSurMap(feuilleLac, "#", 0, 1);
            AddElementDecorSurMap(tronLac, "|", 0, 1);
            AddElementDecorSurMap(smoothFrontLac, "(", 0, 1);
            AddElementDecorSurMap(smoothBackLac, ")", 0, 1);
            AddElementDecorSurMap(sharpFrontLac, "/", 0, 1);
            AddElementDecorSurMap(sharpBackLac, "\\", 0, 1);
            AddElementDecorSurMap(shadowLac, "¨", 0, 1);
            AddElementDecorSurMap(flatLac, "_", 0, 1);
            AddElementDecorSurMap(fishLac, ".", 0, 1);
            // placement cimetiere sur map zone 2 nord
            AddElementDecorSurMap(tronCimtery, "|", 2, 0);
            AddElementDecorSurMap(flatCimtery, "_", 2, 0);
            AddElementDecorSurMap(shadowCimtery, "¨", 2, 0);
            // placement cimetiere sur map zone 2 sud
            AddElementDecorSurMap(tronCimtery, "|", 2, 1);
            AddElementDecorSurMap(flatCimtery, "_", 2, 1);
            AddElementDecorSurMap(shadowCimtery, "¨", 2, 1);
            // placement village sur map zone 0 nord
            AddElementDecorSurMap(feuilleVillage, "#", 0, 0);
            AddElementDecorSurMap(tronVillage, "|", 0, 0);
            AddElementDecorSurMap(flatVillage, "_", 0, 0);
            AddElementDecorSurMap(briqueVillage, "-", 0, 0);
            AddElementDecorSurMap(sharpFrontVillage, "/", 0, 0);
            AddElementDecorSurMap(sharpBackVillage, "\\", 0, 0);
            AddElementDecorSurMap(buissonVillage, "x", 0, 0);
            AddElementDecorSurMap(fenetreVillage, ".", 0, 0);

            // ajout Joueur sur map

            AddElementMonde(joueurMap.WhereNumCarte, joueurMap.WherePos, joueurMap.Symbole);
   
        }

        public void RafraichirMap()
        {
            monde = new List<string[]>();
            MapConstruct();
            AddMonstresSurMap(groupeMonstresCheminCentralMap);
            AddMonstresSurMap(groupeMonstresForetNordMap);
            AddMonstresSurMap(groupeMonstresForetSudMap);
            AddMonstresSurMap(groupeMonstresLacMap);
            AddMonstresSurMap(groupeMonstresMontagneNordMap);
            AddMonstresSurMap(groupeMonstresMontagneSudMap);
            AddMonstresSurMap(groupeMonstresPlaineNordMap);
            AddMonstresSurMap(groupeMonstresPlaineSudMap);
        }

        public void BuildMonsters()
        {
            CreateMonstres(groupeMonstresForetNordMap, 1);
            CreateMonstres(groupeMonstresPlaineNordMap, 2);
            CreateMonstres(groupeMonstresMontagneNordMap, 3);
            CreateMonstres(groupeMonstresCheminCentralMap, 4);
            CreateMonstres(groupeMonstresLacMap, 5);
            CreateMonstres(groupeMonstresMontagneSudMap, 6);
            CreateMonstres(groupeMonstresPlaineSudMap, 7);
            CreateMonstres(groupeMonstresForetSudMap, 8);
        }

        public void CreateMonstres(List<Monstre> groupeMonstres,int zone )
        {
            Random rnd = new Random();
            int numCarte, pos;
            for (int i = 0; i < groupeMonstres.Count; i++)
            {
                do
                {
                    switch (zone)
                    {
                        case 1:
                            pos = rnd.Next(zoneForetNordLimitMin[1], zoneForetNordLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneForetNordLimitMin[0], zoneForetNordLimitMax[0] + 1);
                            break;
                        case 2:
                            pos = rnd.Next(zonePlaineNordLimitMin[1], zonePlaineNordLimitMax[1] + 1);
                            numCarte = rnd.Next(zonePlaineNordLimitMin[0], zonePlaineNordLimitMax[0] + 1);
                            break;
                        case 3:
                            pos = rnd.Next(zoneMontagneNordLimitMin[1], zoneMontagneNordLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneMontagneNordLimitMin[0], zoneMontagneNordLimitMax[0] + 1);
                            break;
                        case 4:
                            pos = rnd.Next(zoneCheminLimitMin[1], zoneCheminLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneCheminLimitMin[0], zoneCheminLimitMax[0] + 1);
                            break;
                        case 5:
                            pos = rnd.Next(zoneLacLimitMin[1], zoneLacLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneLacLimitMin[0], zoneLacLimitMax[0] + 1);
                            break;
                        case 6:
                            pos = rnd.Next(zoneMontagneSudLimitMin[1], zoneMontagneSudLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneMontagneSudLimitMin[0], zoneMontagneSudLimitMax[0] + 1);
                            break;
                        case 7:
                            pos = rnd.Next(zonePlaineSudLimitMin[1], zonePlaineSudLimitMax[1] + 1);
                            numCarte = rnd.Next(zonePlaineSudLimitMin[0], zonePlaineSudLimitMax[0] + 1);
                            break;
                        case 8:
                            pos = rnd.Next(zoneForetSudLimitMin[1], zoneForetSudLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneForetSudLimitMin[0], zoneForetSudLimitMax[0] + 1);
                            break;
                        default:
                            pos = rnd.Next(zoneCheminLimitMin[1], zoneCheminLimitMax[1] + 1);
                            numCarte = rnd.Next(zoneCheminLimitMin[0], zoneCheminLimitMax[0] + 1);
                            break;
                    }
                } while (monde.ElementAt(numCarte)[pos] != " ");
                groupeMonstres[i].WhereNumCarte = numCarte;
                groupeMonstres[i].WherePos = pos;
            }
        }

       public void AddMonstresSurMap(List<Monstre> groupeMonstres)
        {
            for (int i = 0; i < groupeMonstres.Count; i++)
            {
                if (groupeMonstres[i].Vie > 0)
                {
                    AddElementMonde(groupeMonstres[i].WhereNumCarte, groupeMonstres[i].WherePos, groupeMonstres[i].Symbole);
                }
                
            }
        }
            
        
        public void AddElementDecorSurMap(List<int[]> ElementDecor,string c, int zone, int sud) 
        {
            for (int i = 0; i < ElementDecor.Count; i++)
            {
                for (int j = 0; j < ElementDecor.ElementAt(i).Count(); j++)
                {
                    AddElementMonde(i+sud*13, ElementDecor.ElementAt(i)[j]+zone*20, c);
                }
            }
        }
        public void BuildTree()
        {
            feuilleArbre.Add(new int[] { });
            feuilleArbre.Add(new int[] { 3, 4, 10, 11, 12 });
            feuilleArbre.Add(new int[] { 2, 3, 4, 5, 10, 11, 12});
            feuilleArbre.Add(new int[] { });
            feuilleArbre.Add(new int[] { });
            feuilleArbre.Add(new int[] { 3, 13 });
            feuilleArbre.Add(new int[] { 2, 3, 4, 12, 13, 14 });
            feuilleArbre.Add(new int[] { });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] {3, 4, 11 });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] { });
            tronArbre.Add(new int[] {3,13 });

        }
        public void BuildMountain()
        {
            frontMountain.Add(new int[] { });
            frontMountain.Add(new int[] {12});
            frontMountain.Add(new int[] {9});
            frontMountain.Add(new int[] { });
            frontMountain.Add(new int[] {14});
            frontMountain.Add(new int[] {6,13});
            frontMountain.Add(new int[] {4});
            frontMountain.Add(new int[] {2});
            platMountain.Add(new int[] { });
            platMountain.Add(new int[] {10});
            platMountain.Add(new int[] { });
            platMountain.Add(new int[] { });
            platMountain.Add(new int[] { });
            platMountain.Add(new int[] {5});
            platMountain.Add(new int[] {3, 9});
            platMountain.Add(new int[] { });
            backMountain.Add(new int[] { });
            backMountain.Add(new int[] {13});
            backMountain.Add(new int[] {14});
            backMountain.Add(new int[] { });
            backMountain.Add(new int[] {15});
            backMountain.Add(new int[] {7,16});
            backMountain.Add(new int[] {8});
            backMountain.Add(new int[] {10});

        }
        public void BuildLac()
        {
            feuilleLac.Add(new int[] { });
            feuilleLac.Add(new int[] { 3, 4, 5});
            feuilleLac.Add(new int[] { 3, 4, 5, 14, 15, 16 });
            feuilleLac.Add(new int[] { 14, 15, 16 });
            feuilleLac.Add(new int[] { });
            feuilleLac.Add(new int[] { });
            feuilleLac.Add(new int[] { });
            feuilleLac.Add(new int[] { });
            tronLac.Add(new int[] { });
            tronLac.Add(new int[] { });
            tronLac.Add(new int[] { });
            tronLac.Add(new int[] {4});
            tronLac.Add(new int[] {15});
            tronLac.Add(new int[] { });
            tronLac.Add(new int[] { });
            tronLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { });
            smoothFrontLac.Add(new int[] { 4, 10 });
            smoothFrontLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] {11});
            smoothBackLac.Add(new int[] { });
            smoothBackLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] {6});
            sharpFrontLac.Add(new int[] { });
            sharpFrontLac.Add(new int[] {10});
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] { });
            sharpBackLac.Add(new int[] {5});
            flatLac.Add(new int[] { });
            flatLac.Add(new int[] { });
            flatLac.Add(new int[] { });
            flatLac.Add(new int[] { });
            flatLac.Add(new int[] {7,8,9,10});
            flatLac.Add(new int[] {5});
            flatLac.Add(new int[] { });
            flatLac.Add(new int[] {6,7,8,9});
            shadowLac.Add(new int[] { });
            shadowLac.Add(new int[] { });
            shadowLac.Add(new int[] { });
            shadowLac.Add(new int[] { });
            shadowLac.Add(new int[] { });
            shadowLac.Add(new int[] {7, 9});
            shadowLac.Add(new int[] {6 ,8});
            shadowLac.Add(new int[] { });
            fishLac.Add(new int[] { });
            fishLac.Add(new int[] { });
            fishLac.Add(new int[] { });
            fishLac.Add(new int[] { });
            fishLac.Add(new int[] { });
            fishLac.Add(new int[] {8,10 });
            fishLac.Add(new int[] {5,7,9});
            fishLac.Add(new int[] { });

        }
        public void BuildCimtery() 
        {
            tronCimtery.Add(new int[] { });
            tronCimtery.Add(new int[] { });
            tronCimtery.Add(new int[] { 2, 4, 11, 13 });
            tronCimtery.Add(new int[] {6,8});
            tronCimtery.Add(new int[] {15,17 });
            tronCimtery.Add(new int[] {2,4,10,12});
            tronCimtery.Add(new int[] { });
            tronCimtery.Add(new int[] {6,8,14,16});
            flatCimtery.Add(new int[] { });
            flatCimtery.Add(new int[] {3,12});
            flatCimtery.Add(new int[] {7});
            flatCimtery.Add(new int[] {16});
            flatCimtery.Add(new int[] {3,11});
            flatCimtery.Add(new int[] { });
            flatCimtery.Add(new int[] {7,15 });
            flatCimtery.Add(new int[] { });
            shadowCimtery.Add(new int[] { });
            shadowCimtery.Add(new int[] { });
            shadowCimtery.Add(new int[] {3,12 });
            shadowCimtery.Add(new int[] {7});
            shadowCimtery.Add(new int[] {16});
            shadowCimtery.Add(new int[] {3,11 });
            shadowCimtery.Add(new int[] { });
            shadowCimtery.Add(new int[] {7,15 });
        }

        public void BuildVillage()
        {
            feuilleVillage.Add(new int[] { });
            feuilleVillage.Add(new int[] {3});
            feuilleVillage.Add(new int[] {2,3,4});
            feuilleVillage.Add(new int[] { });
            feuilleVillage.Add(new int[] { });
            feuilleVillage.Add(new int[] { });
            feuilleVillage.Add(new int[] { });
            feuilleVillage.Add(new int[] { });
            tronVillage.Add(new int[] { });
            tronVillage.Add(new int[] { });
            tronVillage.Add(new int[] {10,17});
            tronVillage.Add(new int[] {3,10,17 });
            tronVillage.Add(new int[] {10,12,15,17});
            tronVillage.Add(new int[] {});
            tronVillage.Add(new int[] {3,5,7,9});
            tronVillage.Add(new int[] { });
            flatVillage.Add(new int[] { });
            flatVillage.Add(new int[] {11,16});
            flatVillage.Add(new int[] { });
            flatVillage.Add(new int[] {13,14});
            flatVillage.Add(new int[] {5,6,7});
            flatVillage.Add(new int[] { });
            flatVillage.Add(new int[] { });
            flatVillage.Add(new int[] { });
            briqueVillage.Add(new int[] { });
            briqueVillage.Add(new int[] { });
            briqueVillage.Add(new int[] {12,13,14,15});
            briqueVillage.Add(new int[] { });
            briqueVillage.Add(new int[] { });
            briqueVillage.Add(new int[] {6});
            briqueVillage.Add(new int[] { });
            briqueVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] {4});
            sharpFrontVillage.Add(new int[] { });
            sharpFrontVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] {8});
            sharpBackVillage.Add(new int[] { });
            sharpBackVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] { });
            buissonVillage.Add(new int[] {15,16,17});
            buissonVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] { });
            fenetreVillage.Add(new int[] {5,7});
            fenetreVillage.Add(new int[] {4,8});
            fenetreVillage.Add(new int[] { });

        }

        public void AddCarteMonde(string c1, string c2, string c3) 
        {
            string[] carte = new string[79];
            int carteNum = monde.Count;
            string c4 = "│";
            if(carteNum==0)
            { 
                c4 = "┬"; 
            }
            if (carteNum == height+1)
            {
                c4 = "┴";
            }
            carte[0] = c1;
            for (int i = 1; i < carte.Length - 1; i++)
            {
                carte[i] = c2;
                if (!passage.Contains(carteNum))
                {
                    if (i % 20 == 0 && (i != 0 || i != carte.Length - 1))
                    {
                        carte[i] = c4;
                    }
                }          
            }
            carte[carte.Length - 1] = c3;

            monde.Add(carte);
        }
        public void AddElementMonde(int numCarte, int pos, string c1) 
        {
            monde.ElementAt(numCarte)[pos] = c1;
        }
        public void AfficheMap()
        {
            Console.WriteLine("Legends and Dragons\n");
            Console.WriteLine(joueurMap.NameClass + " : " + joueurMap.Name  + "\t\tNiveau : " + joueurMap.Niveau+ "\t\tArme: " + joueurMap.Weapon.Name+  "\t\tVie : " + joueurMap.Vie );
            foreach (String[] carte in  monde)
            {
                for(int i = 0; i < carte.Length; i++)
                {
                    Console.Write(carte[i]);
                }
                Console.WriteLine();
            }
        }
        public void deplaceJoueur()
        {
            
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if(monde.ElementAt(joueurMap.WhereNumCarte -1)[joueurMap.WherePos] == " ")
                    {
                        joueurMap.WhereNumCarte--;
                    }
                    else
                    {
                        if (EstCeUnMonstre(joueurMap.WhereNumCarte - 1, joueurMap.WherePos))
                        {
                            RejoindreAreneDeCombat(joueurMap, MonstreChallengeur);
                            Console.ReadKey(true);
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (monde.ElementAt(joueurMap.WhereNumCarte + 1)[joueurMap.WherePos] == " ")
                    {
                        joueurMap.WhereNumCarte++;
                        
                    }
                    else
                    {
                        if (EstCeUnMonstre(joueurMap.WhereNumCarte + 1, joueurMap.WherePos))
                        {
                            RejoindreAreneDeCombat(joueurMap, MonstreChallengeur);
                            Console.ReadKey(true);
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (monde.ElementAt(joueurMap.WhereNumCarte)[joueurMap.WherePos+1] == " ")
                    {
                        joueurMap.WherePos++;
                    }
                    else
                    {
                        if (EstCeUnMonstre(joueurMap.WhereNumCarte, joueurMap.WherePos+1))
                        {
                            RejoindreAreneDeCombat(joueurMap, MonstreChallengeur);
                            Console.ReadKey(true);
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (monde.ElementAt(joueurMap.WhereNumCarte)[joueurMap.WherePos-1] == " ")
                    {
                        joueurMap.WherePos--;
                    }
                    else
                    {
                        if (EstCeUnMonstre(joueurMap.WhereNumCarte, joueurMap.WherePos-1))
                        {
                            RejoindreAreneDeCombat(joueurMap, MonstreChallengeur);
                            Console.ReadKey(true);
                        }
                    }
                    break;
                default:
                    break;
            }
            PressedKeyMap = pressedKey.Key;
            RafraichirMap();
        }
        public bool EstCeUnMonstre(int numCarteMonstre, int posMonstre)
        {
            bool presenceMonstre = false;
            foreach (Monstre mob in groupeMonstresCheminCentralMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    presenceMonstre = true;
                    MonstreChallengeur = mob;
                }
            }
            foreach (Monstre mob in groupeMonstresForetNordMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    presenceMonstre = true;
                    MonstreChallengeur = mob;
                }
            }
            foreach (Monstre mob in groupeMonstresPlaineNordMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    presenceMonstre = true;
                    MonstreChallengeur = mob;
                }

            }
            foreach (Monstre mob in groupeMonstresMontagneNordMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    presenceMonstre = true;
                    MonstreChallengeur = mob;
                }

            }
            foreach (Monstre mob in groupeMonstresLacMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    presenceMonstre = true;
                    MonstreChallengeur = mob;
                }

            }
            foreach (Monstre mob in groupeMonstresForetSudMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    if (mob.WhereNumCarte == numCarteMonstre && mob.WherePos == posMonstre)
                    {
                        presenceMonstre = true;
                        MonstreChallengeur = mob;
                    }
                }
            }
            foreach (Monstre mob in groupeMonstresPlaineSudMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    if (mob.WhereNumCarte == numCarteMonstre && mob.WherePos== posMonstre)
                    {
                        presenceMonstre = true;
                        MonstreChallengeur = mob;
                    }
                }

            }
            foreach (Monstre mob in groupeMonstresMontagneSudMap)
            {
                if (monde.ElementAt(numCarteMonstre)[posMonstre] == mob.Symbole)
                {
                    if (mob.WhereNumCarte == numCarteMonstre && mob.WherePos == posMonstre)
                    {
                        presenceMonstre = true;
                        MonstreChallengeur = mob;
                    }
                }

            }
            return presenceMonstre;
        }

        public void RejoindreAreneDeCombat(Joueur jouer, Monstre monstre)
        {
            Arene areneDeCombat = new();
            areneDeCombat.ajouteCombatants(jouer, monstre);
            while (areneDeCombat.FinDeCombat != true)
            {
                areneDeCombat.AfficheRoundDebut();
            }
            areneDeCombat.AfficheRoundFin();
            RafraichirMap();
        }
           
    }
}
