
using FinalGame.Functions.Menu;
using System;
using System.Collections.Generic;

namespace FinalGame.Functions.Menus
{
    class MainMenu
    {

        private readonly int SizeX = 20, SizeY = 13;
        private readonly int PositionLeft = 15, PositionTop = 5;

        private List<MenuOption> menuOptions = new List<MenuOption>();

        //private int CursorPositionX, CursorPositionY;
        private int SelectedOption = 1;
        static bool started = false;
        public int DrawMenu()
        {
            // Narysuj obramówke menu 
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            //Dodaj i wypisz opcje
            RefreshOptions();

            return SelectAction(menuOptions);
        }
        public int SelectAction(List<MenuOption> menuOptions)
        {

            while (true)
            {

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
                        if (started)
                            return SelectedOption - 1;
                        else return SelectedOption;
                    case ConsoleKey.X:
                        return 4;
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

            if (started)
            {
                menuOptions.Add(new MenuOption("| Pause Menu |", PaddingLeft - 3, PaddingTop - 2));
                menuOptions.Add(new MenuOption(" New Game ", PaddingLeft, PaddingTop + 2));
                menuOptions.Add(new MenuOption(" Resume ", PaddingLeft, PaddingTop + 4));
            }
            else
            {
                menuOptions.Add(new MenuOption("| Menu |", PaddingLeft, PaddingTop - 2));
                menuOptions.Add(new MenuOption(" Start    ", PaddingLeft, PaddingTop + 4));
            }
            menuOptions.Add(new MenuOption(" Options ", PaddingLeft, PaddingTop + 6));
            menuOptions.Add(new MenuOption(" Controls ", PaddingLeft, PaddingTop + 8));
            menuOptions.Add(new MenuOption(" Exit  ", PaddingLeft, PaddingTop + 10));

            foreach (MenuOption o in menuOptions)
                o.Draw();
        }
        public static bool getStarted()
        {
            return started;
        }

        public static void setStarted()
        {
            started = true;
        }

        public static void Reset()
        {
            started = false;
        }
    }
}
