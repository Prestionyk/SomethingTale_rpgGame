using System;
using System.Threading;

namespace FinalGame
{
    class ASCIIART
    {
        static string[] intro = {"    Studio NoName presents\n",
                                 "Amazing game, family friendly\n" };

        static string[] gameName = {
                                    " ██████  ▒█████   ███▄ ▄███▓▓█████▄▄▄█████▓ ██░ ██  ██▓ ███▄    █   ▄████ ▄▄▄█████▓ ▄▄▄       ██▓    ▓█████   \n" ,
                                    "▒██    ▒ ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀▓  ██▒ ▓▒▓██░ ██▒▓██▒ ██ ▀█   █  ██▒ ▀█▒▓  ██▒ ▓▒▒████▄    ▓██▒    ▓█   ▀  \n" ,
                                    "░ ▓██▄   ▒██░  ██▒▓██    ▓██░▒███  ▒ ▓██░ ▒░▒██▀▀██░▒██▒▓██  ▀█ ██▒▒██░▄▄▄░▒ ▓██░ ▒░▒██  ▀█▄  ▒██░    ▒███    \n" ,
                                    "  ▒   ██▒▒██   ██░▒██    ▒██ ▒▓█  ▄░ ▓██▓ ░ ░▓█ ░██ ░██░▓██▒  ▐▌██▒░▓█  ██▓░ ▓██▓ ░ ░██▄▄▄▄██ ▒██░    ▒▓█  ▄  \n" ,
                                    "▒██████▒▒░ ████▓▒░▒██▒   ░██▒░▒████▒ ▒██▒ ░ ░▓█▒░██▓░██░▒██░   ▓██░░▒▓███▀▒  ▒██▒ ░  ▓█   ▓██▒░██████▒░▒████▒ \n" ,
                                    "▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░ ▒ ░░    ▒ ░░▒░▒░▓  ░ ▒░   ▒ ▒  ░▒   ▒   ▒ ░░    ▒▒   ▓▒█░░ ▒░▓  ░░░ ▒░ ░ \n" ,
                                    "░ ░▒  ░ ░  ░ ▒ ▒░ ░  ░      ░ ░ ░  ░   ░     ▒ ░▒░ ░ ▒ ░░ ░░   ░ ▒░  ░   ░     ░      ▒   ▒▒ ░░ ░ ▒  ░ ░ ░  ░ \n" ,
                                    "░  ░  ░  ░ ░ ░ ▒  ░      ░      ░    ░       ░  ░░ ░ ▒ ░   ░   ░ ░ ░ ░   ░   ░        ░   ▒     ░ ░      ░    \n" ,
                                    "       ░      ░ ░         ░      ░  ░         ░  ░  ░ ░           ░       ░                ░  ░    ░  ░   ░  ░" };

        static string[] gameOver = {
                                 "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n",
                                 " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n" ,
                                 "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n" ,
                                 "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n" ,
                                 "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n" ,
                                 " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n" ,
                                 "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n" ,
                                 "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n" ,
                                 "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n" ,
                                 "      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     \n" };
        public static void Intro()
        {

            Thread write = new Thread(WriteIntro);

            write.Start();
            write.Join();
        }

        public static void GameOver()
        {
            Thread write = new Thread(WriteGameOver);

            write.Start();
            write.Join();

        }

        static void WriteIntro()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < intro.Length; i++)
            {
                Console.SetCursorPosition(45, 10 + i);
                Console.Write(intro[i]);
                Thread.Sleep(1500);
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < gameName.Length; i++)
            {
                Console.SetCursorPosition(10, 6 + i);
                Console.Write(gameName[i]);
                Thread.Sleep(250);
            }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }

        static void WriteGameOver()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition(25, 6 + i);
                Console.Write(gameOver[i]);
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
