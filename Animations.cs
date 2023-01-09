using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameProject
{
    class Animations
    {
        //Clignotement de string
        public static void Blink(string text, int blinkCount = 5, int onTime = 500, int offTime = 200)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < blinkCount; i++)
            {
                Console.WriteLine(text);
                Thread.Sleep(onTime);
                Console.Clear();
                Thread.Sleep(offTime);

            }
            Console.WriteLine(text);
            Console.CursorVisible = true;
        }
        //Apparition de gauche à droite du string
        public static void Typing(string text, int delay = 2)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(delay);

                //Stop animation avec Enter
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo= Console.ReadKey(true);
                    if(keyInfo.Key == ConsoleKey.Enter) {
                        Console.Write(text.Substring(i + 1));
                        break;
                    }
                }

            }

        }
        //Apparation l'un sur l'autre du string pour créer une animation d'un emote ou un personnage
        public static void Frames(string[] frames, int nbTimes = 3, int delay = 100)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < nbTimes; i++)
            {
                foreach(string frame in frames)
                {
                    Console.SetCursorPosition(0, 0);
                    //Console.Clear();
                    Console.WriteLine(frame);
                    Thread.Sleep(delay);
                }
            }
            Console.CursorVisible = true;
        }

    }
}
