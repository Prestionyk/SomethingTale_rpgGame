using System;
using System.Collections.Generic;

namespace FinalGame.Functions.Menu
{
    class ControlsMenu
    {
        private static int SizeX = 30, SizeY = 20;
        private static int PositionLeft = 15, PositionTop = 5;
        static ConsoleKeyInfo chose;
        private static Dictionary<string, char> Controls = new Dictionary<string, char>()
        {
            {"Up",'↑'},{"Down",'↓'},{"Right",'→'},{"Left",'←'},{"Confirm",'Z'},{"Enter",'E'},{"Cancel",'X'},{"Show/Add stats",'C' },{"Info",'I'}
        };

        private static List<MenuOption> menuOptions = new List<MenuOption>();

        public static void DrawControls()
        {

            Console.Clear();
            menuOptions.Clear();
            int PaddingLeft = PositionLeft + SizeX / 3 + 1;
            int PaddingTop = PositionTop + SizeY / 5 + 1;

            menuOptions.Add(new MenuOption($"|Controls|", PaddingLeft, PaddingTop - 3));
            menuOptions.Add(new MenuOption($" Move up: {Controls["Up"]}", PaddingLeft - 3, PaddingTop));
            menuOptions.Add(new MenuOption($" Move down: {Controls["Down"]}", PaddingLeft - 3, PaddingTop + 2));
            menuOptions.Add(new MenuOption($" Move right: {Controls["Right"]}", PaddingLeft - 3, PaddingTop + 4));
            menuOptions.Add(new MenuOption($" Move left: {Controls["Left"]}", PaddingLeft - 3, PaddingTop + 6));
            menuOptions.Add(new MenuOption($" Confirm action: {Controls["Confirm"]} ", PaddingLeft - 3, PaddingTop + 8));
            menuOptions.Add(new MenuOption($" Enter map/dungeon: {Controls["Enter"]} ", PaddingLeft - 3, PaddingTop + 10));
            menuOptions.Add(new MenuOption($" Cancel/back: {Controls["Cancel"]} ", PaddingLeft - 3, PaddingTop + 12));
            menuOptions.Add(new MenuOption($" Show/Add stats: {Controls["Show/Add stats"]} ", PaddingLeft - 3, PaddingTop + 14));
            menuOptions.Add(new MenuOption($" Info: {Controls["Info"]} ", PaddingLeft - 3, PaddingTop + 16));

            DrawFrame.Draw(PositionLeft, PositionTop, SizeX, SizeY);
            foreach (MenuOption option in menuOptions)
                option.Draw();

            do
            {
                chose = Console.ReadKey(true);

            } while (chose.KeyChar != 'x' & chose.KeyChar != 'z');
            Console.Clear();

        }
    }
}
