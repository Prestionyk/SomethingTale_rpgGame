using FinalGame.Functions.Menus;
using System.Collections.Generic;

namespace FinalGame
{
    static class Create
    {
        //////////////DEFAULT ADVENTURE//////////////
        public static Adventure NewAdventure(bool newPlayer = false)
        {
            MainMenu.Reset();
            World.indexer = 0;

            Player player = new Player(newPlayer);

            Skeleton Skeleton = new Skeleton();
            Skeleton Skeleton1 = new Skeleton();
            Slime s = new Slime();
            Guardian guardian = new Guardian();

            Dungeon dungeon = new Dungeon();
            Dungeon dungeon2 = new Dungeon();
            Dungeon dungeon3 = new Dungeon();
            Fight Fight_1 = new Fight();
            Fight Fight_2 = new Fight();

            Fight_1 += Skeleton;
            Fight_1 += Skeleton1;
            Fight_1 += s;
            Fight_2 += guardian;

            dungeon += Fight_1;
            dungeon2 += Fight_2;
            dungeon3 += Fight_1;
            dungeon3 += Fight_2;
            ///////////////////////////////////////////////////

            List<World> Worlds = new List<World>() {

            new World(@"Maps\Start.txt"),                  ///0
            new World(@"Maps\Route.txt"),                  ///1
            new World(@"Maps\CrossRoute.txt"),             ///2
            new World(@"Maps\LargeMap.txt"),               ///3
            new World(@"Maps\House1_pt.txt",dungeon),      ///4
            new World(@"Maps\House2_pt.txt",dungeon2),     ///5 
            new World(@"Maps\Labirynt.txt",dungeon3)       ///6
            };

            //////////////MAP ROUTES//////////////
            Worlds[0].addEntrance(9, 48, 1);
            Worlds[1].addEntrance(12, 38, 2);
            Worlds[2].addEntrance(13, 70, 3);
            Worlds[1].addEntrance(8, 1, 0);
            Worlds[2].addEntrance(16, 0, 1);
            Worlds[3].addEntrance(11, 1, 2);
            Worlds[4].addEntrance(1, 31, 3);
            Worlds[5].addEntrance(27, 95, 3);
            Worlds[3].addEntrance(2, 8, 4);
            Worlds[3].addEntrance(2, 36, 5);
            Worlds[3].addEntrance(13, 42, 6);
            Worlds[6].addEntrance(2, 2, 3);

            Adventure Adventure = new Adventure(Worlds, player);
            return Adventure;
        }
        
    }
}
