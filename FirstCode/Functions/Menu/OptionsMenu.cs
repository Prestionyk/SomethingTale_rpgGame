using FinalGame.Functions.Menu;
using FinalGame.Music;
using System;
using System.Collections.Generic;

namespace FinalGame.Functions.Menus
{
    class OptionsMenu
    {
        private readonly int SizeX = 65, SizeY = 11;
        private readonly int PositionLeft = 15, PositionTop = 5;

        private List<MenuOption> menuOptions = new List<MenuOption>();

        private int SelectedOption = 1;
        public void DrawOptionsMenu()
        {
            Console.Clear();
            // Narysuj obramówke menu 
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            // Wybierz opcję
            SelectAction(menuOptions);
            Console.Clear();
        }
        public void SelectAction(List<MenuOption> menuOptions)
        {
            while (true)
            {
                //Dodaj i wypisz opcje
                RefreshOptions();

                Console.ForegroundColor = Program.HighlightColor;
                Console.SetCursorPosition(menuOptions[SelectedOption].GetX() - 2, menuOptions[SelectedOption].GetY());
                Console.Write(">");
                menuOptions[SelectedOption].Draw();
                Console.ResetColor();

                int previousSelection = SelectedOption;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.UpArrow:
                        SelectedOption -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption += 1;
                        break;

                    case ConsoleKey.Z: //Potwierdzenie wyboru
                        if (SelectedOption == 1)
                        {
                            if (Sound.get())
                            {
                                CyberIntro.Stop();
                                Sound.change();
                            }
                            else
                            {
                                Sound.change();
                                CyberIntro.Play();
                            }
                        }
                        if (SelectedOption == 2)
                            Difficulty.change();
                        break;
                    case ConsoleKey.X:
                        return;
                }

                if (SelectedOption < 1 || SelectedOption > menuOptions.Count - 1)
                    SelectedOption = previousSelection;

                Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 2, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
            }
        }

        public void RefreshOptions()
        {
            Console.CursorVisible = false;
            DrawFrame.ClearFrame(SizeX, SizeY, PositionLeft, PositionTop);
            menuOptions.Clear();

            int PaddingLeft = PositionLeft + SizeX / 3 + 1;
            int PaddingTop = PositionTop + SizeY / 5 + 1;

            menuOptions.Add(new MenuOption("| Options |", PaddingLeft + 6, PaddingTop - 2));
            if (Sound.get())
                menuOptions.Add(new MenuOption(" Turn OFF Sound ", PaddingLeft - 16, PaddingTop));
            else menuOptions.Add(new MenuOption(" Turn ON Sound ", PaddingLeft - 16, PaddingTop));
            menuOptions.Add(new MenuOption($" Difficulty {Difficulty.Get()} [Cannot be change when game started]", PaddingLeft - 16, PaddingTop + 2));

            foreach (MenuOption o in menuOptions)
                o.Draw();
        }
    }
}
