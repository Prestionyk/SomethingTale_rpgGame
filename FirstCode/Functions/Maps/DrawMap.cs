using System;

namespace FinalGame.Functions
{
    static class DrawMap
    {
        static ConsoleKeyInfo chose;
        static string[] fileMap = System.IO.File.ReadAllText(@"Maps\Map.txt").Split(';');
        public static void Draw(int index)
        {

            Console.Clear();
            Write.Info($"{fileMap[index]}");

            do
            {
                chose = Console.ReadKey(true);

            } while (chose.KeyChar != 'm' & chose.KeyChar != 'z');
            Console.Clear();
        }

    }
}
