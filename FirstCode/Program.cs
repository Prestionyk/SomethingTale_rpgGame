using FinalGame.Functions.Menu;
using FinalGame.Functions.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalGame
{
    class Program
    {
        public static readonly ConsoleColor HighlightColor = ConsoleColor.Yellow;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(125, 35);

            Adventure Adventure = new Adventure(new List<World>(), new Player());
            MainMenu Menu = new MainMenu();
            OptionsMenu Options = new OptionsMenu();

            ASCIIART.Intro();

            bool play = true;
            while (play)
            {
                if (Adventure.checkReset())
                    Adventure = Create.NewAdventure();

                switch (Menu.DrawMenu())
                {
                    case 0:
                        MainMenu.Reset();
                        break;
                    case 1:
                        {
                            if (!MainMenu.getStarted() || Adventure.checkReset())
                            {
                                Adventure = Create.NewAdventure(true);
                            }
                            Adventure.Play();
                            MainMenu.setStarted();
                            break;
                        }
                    case 2:
                        Options.DrawOptionsMenu();
                        break;
                    case 3:
                        ControlsMenu.DrawControls();
                        break;
                    case 4:
                        Console.Clear();
                        play = false;
                        break;
                }
            }
        }
    }

}
