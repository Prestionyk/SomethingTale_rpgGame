using System;

namespace FinalGame.Functions.Menu
{
    class DrawFrame
    {
        public static void Draw(int PositionLeft, int PositionTop, int SizeX, int SizeY)
        {
            Console.SetCursorPosition(PositionLeft, PositionTop);
            Console.Write("╔" + new string('═', SizeX) + "╗");
            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
                Console.Write("║");
                Console.SetCursorPosition(PositionLeft + SizeX + 1, Console.CursorTop);
                Console.Write("║");
            }
            Console.SetCursorPosition(PositionLeft, Console.CursorTop + 1);
            Console.Write("╚" + new string('═', SizeX) + "╝");
        }

        public static void ClearFrame(int SizeX, int SizeY, int PositionLeft, int PositionTop)
        {
            for (int i = 0; i <= SizeY; i++)
            {
                Console.SetCursorPosition(PositionLeft + 1, PositionTop + 1 + i);
                Console.Write(new string(' ', SizeX));
            }
        }
    }
}
