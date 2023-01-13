using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime;

namespace LegendsAndDragons
{
    class Game
    {
        public Hero joueur { set; get; }
        public List<Monstre> groupeMonstresForetNord { get; set; } = new();
        public List<Monstre> groupeMonstresPlaineNord { get; set; } = new();
        public List<Monstre> groupeMonstresMontagneNord { get; set; } = new();
        public List<Monstre> groupeMonstresCheminCentral { get; set; } = new();
        public List<Monstre> groupeMonstresLac { get; set; } = new();
        public List<Monstre> groupeMonstresMontagneSud { get; set; } = new();
        public List<Monstre> groupeMonstresPlaineSud { get; set; } = new();
        public List<Monstre> groupeMonstresForetSud { get; set; } = new();



        public void Start()
        {
            Console.Title = "Legends and dragons";

            // On vérifie l'OS puis on lance la music  avec windows puisque linux et mac ne fonctionne pas
            if (OperatingSystem.IsWindows())
            {
                //Sound/Musique BGM seulement supporter sur WINDOWS fait appel au fichier System.Windows.Extensions.dll
                //SoundPlayer sound = new SoundPlayer(@"C:\Users\olivi\source\repos\GameProject\sound\battledragons.wav");
                //sound.PlayLooping();

            }
            RunMainMenu();
        }
        private void RunMainMenu()
        {
            string prompt = @"
  _                               _                        _        _                                 
 | |                             | |                      | |      | |                                
 | |     ___  __ _  ___ _ __   __| |___     __ _ _ __   __| |    __| |_ __ __ _  __ _  ___  _ __  ___ 
 | |    / _ \/ _` |/ _ \ '_ \ / _` / __|   / _` | '_ \ / _` |   / _` | '__/ _` |/ _` |/ _ \| '_ \/ __|
 | |___|  __/ (_| |  __/ | | | (_| \__ \  | (_| | | | | (_| |  | (_| | | | (_| | (_| | (_) | | | \__ \
 |______\___|\__, |\___|_| |_|\__,_|___/   \__,_|_| |_|\__,_|   \__,_|_|  \__,_|\__, |\___/|_| |_|___/
              __/ |                                                              __/ |                
             |___/                                                              |___/                           
Bienvenu";


            //Menu array
            string[] options = { "Lancement du jeu", "Info sur les développeurs", "Quitter le jeux" };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            //Dependant l'index sélectionner on execute les méthodes
            switch (selectedIndex)
            {
                case 0:
                    NewGame();
                    break;
                case 1:
                    InfoDev();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        private void NewGame()
        {
            //Creation des monstres par zone
                  //Zone 1 : Foret maudite du nord
            groupeMonstresForetNord.Add(new("Sanglier des ardennes"));
            groupeMonstresForetNord.Add(new("Plante sauvage"));
            groupeMonstresForetNord.Add(new("Monstre des bois"));
                  //Zone 2 : Plaine cachée du nord
            groupeMonstresPlaineNord.Add(new("Zombie infecté"));
            groupeMonstresPlaineNord.Add(new("Loup garou"));
            groupeMonstresPlaineNord.Add(new("Aigle royal"));
                  //Zone 3 et 6: Montagne sacrée du nord
            groupeMonstresMontagneNord.Add(new("Dragon de feu"));
            groupeMonstresMontagneNord.Add(new("Dragon de glace"));
            groupeMonstresMontagneNord.Add(new("Ogre"));
                    //Zone 4 : Chemin du voyageur
            Monstre gobelin = new("Gobelin");
            Monstre araignee = new("Araignée");
            groupeMonstresCheminCentral.Add(gobelin);
            groupeMonstresCheminCentral.Add(araignee);
                    //Zone 5 : Lac enchantée
            Monstre marrais = new("Monstre des marrais");
            Monstre sorciere = new("Sorciere des buissons");
            groupeMonstresLac.Add(marrais);
            groupeMonstresLac.Add(sorciere);
                  //Zone  6: Montagne sacrée du sud
            groupeMonstresMontagneSud.Add(new("Dragon de feu"));
            groupeMonstresMontagneSud.Add(new("Dragon de glace"));
            groupeMonstresMontagneSud.Add(new("Ogre"));
                  //Zone 7: Plaine cachée du sud
            groupeMonstresPlaineSud.Add(new("Zombie infecté"));
            groupeMonstresPlaineSud.Add(new("Loup garou"));
            groupeMonstresPlaineSud.Add(new("Aigle royal"));
                  //Zone 8 : Foret maudite du sud
            groupeMonstresForetSud.Add(new("Sanglier des ardennes"));
            groupeMonstresForetSud.Add(new("Plante sauvage"));
            groupeMonstresForetSud.Add(new("Monstre des bois"));
            Console.Clear();
            string prompt = "Sélectionner votre personnage ?";
            string[] options = { "Warlock", "Knight", "Hunter" };
            Menu CharachterMenu = new Menu(prompt, options);
            int selectedIndex = CharachterMenu.Run();
            Console.WriteLine();
            Console.Write("Quelle est ton nom : ");
            string name = Console.ReadLine();
            switch (selectedIndex)
            {
                case 0:
                    Warlock(name);
                    break;
                case 1:
                    Knight(name);
                    break;
                case 2:
                    Hunter(name);
                    break;
                
            }
            Map map = new(groupeMonstresForetNord, groupeMonstresPlaineNord, groupeMonstresMontagneNord,
                groupeMonstresCheminCentral, groupeMonstresLac, groupeMonstresForetSud,
                    groupeMonstresPlaineSud, groupeMonstresMontagneSud, joueur);
            do
            {
                Console.Clear();
                map.AfficheMap();
                map.deplaceJoueur();

            } while (map.PressedKeyMap != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("\n \t_Sortie de Jeu.");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void InfoDev()
        {
            Console.Clear();
            Console.WriteLine("\nJeu : Legends and Dragons \n");
            Console.WriteLine("C'est un jeu de rôle développé par un groupe etudiants de 2eme Bachelier d'informatique de gestion.");
            Console.WriteLine("");
            Console.WriteLine("Membres du groupe :");
            Console.WriteLine("\tSebastien - Gael - Olivier - Ozgur");
            Console.WriteLine("");
            Console.WriteLine("Professeur : Jeremy Kairis");
            Console.WriteLine("");
            Console.WriteLine("Etablissement : IFOSUP");
            Console.ReadKey(true);
            RunMainMenu();

        }
        private void ExitGame()
        {
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void Warlock(string name)
        {
            joueur = new(name, "Warlock");

        }
        private void Knight(string name)
        {
            joueur = new(name, "Knight");
        }
        private void Hunter(string name)
        {
            joueur = new(name, "Hunter");
        }
     
    }
}