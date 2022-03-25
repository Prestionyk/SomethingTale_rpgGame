using FinalGame.Functions.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalGame.Functions.Other
{
    class StatDescription
    {
        private static int SizeX = 65, SizeY = 5;
        private static int PositionLeft = 15, PositionTop = 5;
        static ConsoleKeyInfo chose;

        private static Dictionary<string,string[]> descriptions = new Dictionary<string, string[]> {
            {"MAXHP", new string[]
            {"MAXHP - po prostu zwiększa pulę twojego życia.",
             "Jesteś wstanie wytrzymać więcej ataków.",
             "Super nie?!" } 
            },

            {"MAXMP", new string[]
            {"MAXMP - mana, mana... moc magiczna,",
             "którą wykorzystujesz by używać magicznych zaklęć.",
             "Jeśli idziesz ścieżką maga, przyda ci się!" } 
            },

            {"STR", new string[]
            {"STR - kimże jest wojownik bez siły? Jakimś słabiakiem...",
             "Zwiększa ilość obrażeń z ataków fizycznych." }
            },

            {"DEF", new string[]
            {"DEF - lubisz być bitym? Śmiało pakuj w obronę.",
             "Fizyczne ataki będą cię łaskotać, niestety",
             "magia przechodzi przez skórę." }
            },

            {"INT", new string[]
            {"INT - inteligencją nie musisz grzeszyć, no",
             "chyba że ciągle wywołujesz magiczne zaklęcia.",
             "Zwiększa efekty twoich magicznych zmagań!" }
            },

            {"AGI", new string[]
            {"AGI - próbowałeś kiedyś złapać mysz tak jak Tom łapie Jerry?",
             "Zwinność pozwoli ci zwiększyć szansę", 
             "na trafienie przeciwnika, trafienie krytyczne",
             "a nawet skoczyć jak małpa i uniknąć ataku!" } 
            }
        };
        public static void Describe(int IndexOfStat)
        {
            switch (IndexOfStat)
            {
                case 1:
                    DrawDescription(descriptions["MAXHP"]);
                    break;
                case 2:
                    DrawDescription(descriptions["MAXMP"]);
                    break;
                case 3:
                    DrawDescription(descriptions["STR"]);
                    break;
                case 4:
                    DrawDescription(descriptions["DEF"]);
                    break;
                case 5:
                    DrawDescription(descriptions["INT"]);
                    break;
                case 6:
                    DrawDescription(descriptions["AGI"]);
                    break;
            }

            do
            {
                chose = Console.ReadKey(true);

            } while (chose.KeyChar != 'x' & chose.KeyChar != 'z');
            Console.Clear();
        }

        private static void DrawDescription(string[] description)
        {
            Console.Clear();
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);

            int i = 2;
            foreach (string d in description)
            {
                Console.SetCursorPosition(PositionLeft + 2, PositionTop + i++);
                Write.Info(d);
            }
        }
    }
}
