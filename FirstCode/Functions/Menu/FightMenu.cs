using FinalGame.Functions;
using FinalGame.Functions.Exceptions;
using FinalGame.Functions.Menu;
using FinalGame.Usable;
using System;
using System.Collections.Generic;

namespace FinalGame
{
    class FightMenu
    {
        public static readonly ConsoleColor HighlightColor = ConsoleColor.Yellow;

        private readonly int SizeX = 50, SizeY = 4;
        private readonly int PositionLeft = 15, PositionTop = 17;

        private readonly int StatMenuSizeX = 11, StatMenuSizeY = 13;
        private readonly int StatsPosLeft = 2, StatsPosTop = 8;
        //private readonly int PaddingLeft, PaddingRight, PaddingTop, PaddingBottom;
        private List<MenuOption> menuOptions = new List<MenuOption>();

        //private int CursorPositionX, CursorPositionY;
        private int SelectedOption = 0;

        public FightMenu()
        {
            int PaddingLeft = PositionLeft + SizeX / 4;
            int PaddingRight = PositionLeft + SizeX - SizeX / 4 - 4;
            int PaddingTop = PositionTop + SizeY / 5 + 2;
            int PaddingBottom = PositionTop + SizeY - SizeY / 4 + 1;

            menuOptions.Add(new MenuOption("Attack", PaddingLeft, PaddingTop));
            menuOptions.Add(new MenuOption("Skill", PaddingRight, PaddingTop));
            menuOptions.Add(new MenuOption("Item", PaddingLeft, PaddingBottom));
            menuOptions.Add(new MenuOption("Defend", PaddingRight, PaddingBottom));

        }

        public void DrawFightMenu()
        {
            // Narysuj obramówke menu 
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            // Narysuj obramówke loga
            DrawFrame.Draw(PositionLeft + SizeX + 2, 0, 44, 21);

            DrawFrame.ClearFrame(SizeX, SizeY, PositionLeft, PositionTop);
            //Wypisz opcje
            foreach (MenuOption o in menuOptions)
                o.Draw();
        }

        public int DrawUsable(List<IUsable> list)
        {
            DrawFrame.ClearFrame(SizeX, SizeY, PositionLeft, PositionTop); //Wyczyść opcje które wcześniej tam były
            if (list.Count == 0)
            {
                Console.SetCursorPosition(PositionLeft + 7, PositionTop + 1);
                Console.Write("<EMPTY>");
                while (true)
                {
                    ConsoleKey key = Controller.GetButton();
                    if (key == ConsoleKey.Z || key == ConsoleKey.X)
                        throw new NoChoiceException();
                }
            }
            List<MenuOption> options = new List<MenuOption>();
            int PosLeft = PositionLeft,
                PosTop = PositionTop;
            PosLeft += SizeX / 6 - 20;
            PosTop++;
            foreach (IUsable i in list)     //Stwórz MenuOption dla każdego itemu
            {

                PosLeft += 20;
                if (PosLeft > PositionLeft + 30)
                {
                    PosTop += 2;
                    PosLeft = PositionLeft + SizeX / 6;
                }
                options.Add(new MenuOption(i.GetName(), PosLeft, PosTop));
                options[options.Count - 1].Draw();      //Wypisz każdą z tych opcji
            }

            SelectedOption = 0;
            return int.Parse(SelectAction(options, 2, true));
        }
        public void DrawStats(Player player)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            DrawFrame.Draw(PosLeft, PosTop -2, StatMenuSizeX, StatMenuSizeY);
            Console.SetCursorPosition(3, 7);
            Write.Info($"Lvl: {player.GetLvl()}");

            List<int> stats = player.GetStats();
            string line = "";
            PosTop--;
            for (int i = 0; i < stats.Count; i++)
            {
                PosTop += 2;
                Console.SetCursorPosition(PosLeft + 2, PosTop);
                switch (i)
                {
                    case 0:
                        line = "HP";
                        break;
                    case 2:
                        line = "MP";
                        break;
                    case 4:
                        line = "STR";
                        break;
                    case 5:
                        line = "DEF";
                        break;
                    case 6:
                        line = "INT";
                        break;
                    case 7:
                        line = "AGI";
                        break;
                }
                if (i <= 2)
                    line += string.Format(" {0, 3}/{1}", stats[i], stats[++i]);
                else
                    line += string.Format(" {0, 5}", stats[i]);
                Console.Write(line);
            }
        }

        public void UpdateStat(Player player, string stat)
        {
            int PosLeft = StatsPosLeft,
                PosTop = StatsPosTop;
            PosTop--;
            int index = 0;
            switch (stat)
            {
                case "HP":
                    index = 0;
                    break;
                case "MP":
                    index = 1;
                    break;
            }
            PosTop += 2 * (index + 1);

            Console.SetCursorPosition(PosLeft + 2 + 3, PosTop);
            if (stat == "HP" || stat == "MP")
                Console.Write(string.Format("{0, 3}/{1}", player.GetStat(stat), player.GetStat("MAX" + stat)));
            else
                Console.Write(string.Format(" {0, 5}", player.GetStat(stat)));
        }


        public string SelectAction() { return SelectAction(menuOptions, 2, false); }

        public string SelectAction(List<MenuOption> menuOptions, int ListWidth, bool ReturnIndex)
        {
            SelectedOption = 0;
            while (true)
            {
                Console.ForegroundColor = HighlightColor;
                Console.SetCursorPosition(menuOptions[SelectedOption].GetX() - 2, menuOptions[SelectedOption].GetY());
                Console.Write(">");
                menuOptions[SelectedOption].Draw();
                Console.ResetColor();

                int previousSelection = SelectedOption;
                switch (Controller.GetButton())
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedOption % ListWidth != 0)
                            SelectedOption--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedOption % ListWidth - 1 != 0)
                            SelectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedOption -= ListWidth;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption += ListWidth;
                        break;

                    case ConsoleKey.Z: //Potwierdzenie wyboru
                        /*if (menuOptions == this.menuOptions)
                            DeselectAction();*/
                        DrawFightMenu();
                        if (!ReturnIndex)
                            return menuOptions[SelectedOption].GetName();
                        else
                            return SelectedOption.ToString();
                    case ConsoleKey.X:
                        throw new NoChoiceException();

                }

                if (SelectedOption < 0 || SelectedOption > menuOptions.Count - 1)
                    SelectedOption = previousSelection;


                /*Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 1, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
                Console.Write(" ");*/
                Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 2, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
            }
        }

        public void DeselectAction()
        {
            Console.SetCursorPosition(menuOptions[SelectedOption].GetX() - 2, menuOptions[SelectedOption].GetY());
            Console.Write(" ");
            menuOptions[SelectedOption].Draw();
        }

    }
}
