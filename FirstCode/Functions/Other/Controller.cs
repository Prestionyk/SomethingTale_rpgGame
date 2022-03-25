using System;

namespace FinalGame
{
    class Controller
    {
        public static ConsoleKey GetButton()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (Console.KeyAvailable)
                Console.ReadKey(true);
            return key;
        }
    }
}
