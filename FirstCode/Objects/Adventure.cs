using FinalGame.Functions;
using FinalGame.Functions.Menu;
using FinalGame.Music;
using System;
using System.Collections.Generic;

namespace FinalGame
{
    public class Adventure
    {
        private List<World> Worlds = new List<World>() { };
        private Player Player;
        private int currentWorld = 0;
        char entrance = '▲', dungeon = '◊';
        bool playerDied = false;
        public Adventure(List<World> worlds, Player player)
        {
            Worlds.AddRange(worlds);
            Player = player;
        }

        public void setMap(int numberOfWorld)
        {
            Console.Clear();
            currentWorld = numberOfWorld;
        }

        public void Play()
        {
            Nightrunning.Play();
            Run();
        }
        public bool checkReset()
        {
            return playerDied;
        }

        private void Run()
        {
            Console.Clear();
            World world = Worlds[currentWorld];
            bool run = true;

            while (run)
            {

                foreach (World var in Worlds)
                {
                    if (currentWorld == var.ID)
                        world = var;
                }

                DrawWorld.Draw(world);

                switch (Controller.GetButton())
                {
                    case ConsoleKey.UpArrow:
                        Step.MovingUp(world);
                        break;
                    case ConsoleKey.DownArrow:
                        Step.MovingDown(world);
                        break;
                    case ConsoleKey.RightArrow:
                        Step.MovingRight(world);
                        break;
                    case ConsoleKey.LeftArrow:
                        Step.MovingLeft(world);
                        break;
                    case ConsoleKey.M:
                        DrawMap.Draw(currentWorld);
                        break;
                    case ConsoleKey.C:
                        Player.Lvl().AddStats(Player);
                        break;
                    case ConsoleKey.I:
                        ControlsMenu.DrawControls();
                        break;
                    case ConsoleKey.E:
                        int newWorld = Enter.World(world, entrance);
                        if (newWorld >= 0)
                            setMap(newWorld);
                        else
                        {
                            if (Enter.Dungeon(world, dungeon))
                            {
                                Console.Clear();
                                Player.Enter(world.getDungeon());
                                Console.Clear();
                                try
                                {
                                    Player.CheckIfDied();
                                }
                                catch (Exception)
                                {
                                    ASCIIART.GameOver();
                                    run = false;
                                    playerDied = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case ConsoleKey.X:
                        Console.Clear();
                        Nightrunning.Stop();
                        CyberIntro.Play();
                        run = false;
                        break;
                }
            }
        }
    }
}
