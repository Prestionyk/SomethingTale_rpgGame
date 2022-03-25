
using FinalGame.Functions;
using FinalGame.Functions.Menu;
using FinalGame.Functions.Other;
using System;
using System.Collections.Generic;

namespace FinalGame.Objects
{
    public class Level
    {
        private int Currentlvl = 1;
        private int CurrentExperience = 0;
        private int ExperienceToNextLvl = 2;
        private int Points = 10;

        private int SizeX = 35, SizeY = 15;
        private int PositionLeft = 15, PositionTop = 5;
        private int SelectedOption = 1;
        static ConsoleKeyInfo chose;
        private List<MenuOption> menuOptions = new List<MenuOption>();

        public void GainExp(int amount)
        {
            CurrentExperience += amount;
            while (CurrentExperience >= ExperienceToNextLvl)
            {
                CurrentExperience -= ExperienceToNextLvl;
                LevelUp();
            }
        }
        private void LevelUp()
        {
            Currentlvl++;
            Points += 3;
            ExperienceToNextLvl = Currentlvl * 2;
            Log.Send("* Level up!");
            Console.SetCursorPosition(3, 7);
            Write.Info($"Lvl: {Currentlvl}");
        }
        public void AddStats(Player player)
        {
            int PHP = 0, PMP = 0, PSTR = 0, PDEF = 0, PINT = 0, PAGI = 0;
            Console.Clear();
            // Draw stats frame 
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);

            while (Points > 0)
            {
                RefreshStats(Points, player);

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
                    case ConsoleKey.I:
                        StatDescription.Describe(SelectedOption);
                        break;
                    case ConsoleKey.Z:
                        switch (SelectedOption)
                        {
                            case 1:
                                player.UpStat("HP", 5);
                                player.UpStat("MAXHP", 5);
                                PHP++;
                                break;
                            case 2:
                                player.UpStat("MP", 5);
                                player.UpStat("MAXMP", 5);
                                PMP++;
                                break;
                            case 3:
                                player.UpStat("STR", 1);
                                PSTR++;
                                break;
                            case 4:
                                player.UpStat("DEF", 1);
                                PDEF++;
                                break;
                            case 5:
                                player.UpStat("INT", 1);
                                PINT++;
                                break;
                            case 6:
                                player.UpStat("AGI", 1);
                                PAGI++;
                                break;
                        }
                        Points--;
                        break;
                    case ConsoleKey.X:
                        switch (SelectedOption)
                        {
                            case 1:
                                if (PHP-- > 0)
                                {
                                    player.UpStat("HP", -5);
                                    player.UpStat("MAXHP", -5);
                                    Points++;
                                }
                                break;
                            case 2:
                                if (PMP-- > 0)
                                {
                                    player.UpStat("MP", -5);
                                    player.UpStat("MAXMP", -5);
                                    Points++;
                                }
                                break;
                            case 3:
                                if (PSTR > 0)
                                {
                                    player.UpStat("STR", -1);
                                    Points++;
                                }
                                break;
                            case 4:
                                if (PDEF > 0)
                                {
                                    player.UpStat("DEF", -1);
                                    Points++;
                                }
                                break;
                            case 5:
                                if (PINT > 0)
                                {
                                    player.UpStat("INT", -1);
                                    Points++;
                                }
                                break;
                            case 6:
                                if (PAGI > 0)
                                {
                                    player.UpStat("AGI", -1);
                                    Points++;
                                }
                                break;
                        }
                        break;
                }

                if (SelectedOption < 1 || SelectedOption + 3 > menuOptions.Count - 1)
                    SelectedOption = previousSelection;

                Console.SetCursorPosition(menuOptions[previousSelection].GetX() - 2, menuOptions[previousSelection].GetY());
                Console.Write(" ");
                menuOptions[previousSelection].Draw();
            }
            RefreshStats(Points, player);
            do
            {
                chose = Console.ReadKey(true);

            } while (chose.KeyChar != 'z');
            Console.Clear();
        }
        private void RefreshStats(int points, Player player)
        {
            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            DrawFrame.ClearFrame(SizeX, SizeY, PositionLeft, PositionTop);
            menuOptions.Clear();

            int PaddingLeft = PositionLeft + SizeX / 3 + 1;
            int PaddingTop = PositionTop + SizeY / 5 + 1;
            
            if(Points > 0)
                menuOptions.Add(new MenuOption($"| Distribute Points |", PaddingLeft - 4, PaddingTop - 3));
            else
                menuOptions.Add(new MenuOption($"| Player Stats |", PaddingLeft - 2, PaddingTop - 3));

            menuOptions.Add(new MenuOption($"[+] MAXHP  {player.GetStat("MAXHP")}", PaddingLeft, PaddingTop));
            menuOptions.Add(new MenuOption($"[+] MAXMP  {player.GetStat("MAXMP")}", PaddingLeft, PaddingTop + 2));
            menuOptions.Add(new MenuOption($"[+] STR  {player.GetStat("STR")}", PaddingLeft, PaddingTop + 4));
            menuOptions.Add(new MenuOption($"[+] DEF  {player.GetStat("DEF")}", PaddingLeft, PaddingTop + 6));
            menuOptions.Add(new MenuOption($"[+] INT  {player.GetStat("INT")}", PaddingLeft, PaddingTop + 8));
            menuOptions.Add(new MenuOption($"[+] AGI  {player.GetStat("AGI")}", PaddingLeft, PaddingTop + 10));
            menuOptions.Add(new MenuOption($"Lvl: {Currentlvl}", PaddingLeft - 10, PaddingTop + 11));
            menuOptions.Add(new MenuOption($"Points left: {points}", PaddingLeft + 8, PaddingTop + 12));
            menuOptions.Add(new MenuOption($"Exp: {CurrentExperience} / {ExperienceToNextLvl}", PaddingLeft - 10, PaddingTop + 12));

            foreach (MenuOption o in menuOptions)
                o.Draw();
        }
        public int GetLevel()
        {
            return Currentlvl;
        }
    }
}
