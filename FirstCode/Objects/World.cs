
using System.Collections.Generic;

namespace FinalGame
{
    public class World
    {

        public static int indexer = 0;
        int pozx = 0;
        int pozy = 0;
        int Sizex;
        int Sizey;
        public int ID;

        public char[,] world = new char[0, 0];
        List<Point2d> Entrances = new List<Point2d>();
        int[] dungeonPlace = new int[2];
        Dungeon dungeon;

        public World(string fileName, Dungeon dungeon = null)
        {
            ID = indexer++;
            this.dungeon = dungeon;

            string[] fileMap = System.IO.File.ReadAllLines(fileName);

            Sizex = fileMap.Length - 1;
            Sizey = fileMap[0].Length - 1;

            world = new char[Sizex + 1, Sizey + 1];

            for (int x = 0; x < fileMap.Length; x++)
            {
                for (int y = 0; y < fileMap[0].Length; y++)
                {
                    world[x, y] = fileMap[x][y];

                    if (fileMap[x][y] == 'X')
                    {
                        pozx = x;
                        pozy = y;
                    }
                    if (fileMap[x][y] == '◊')
                    {
                        dungeonPlace[0] = x;
                        dungeonPlace[1] = y;
                    }

                }
            }

        }

        public Dungeon getDungeon()
        {
            return dungeon;
        }

        public bool haveDungeon()
        {
            if (dungeon != null)
                return true;
            else return false;
        }
        public int GetX()
        {
            return pozx;
        }
        public void setx(int num)
        {
            pozx += num;
        }
        public int GetY()
        {
            return pozy;
        }
        public void sety(int num)
        {
            pozy += num;
        }
        public int GetSizeY()
        {
            return Sizey;
        }
        public int GetSizeX()
        {
            return Sizex;
        }
        public int getIdWorld(int x, int y)
        {
            foreach (Point2d var in Entrances)
            {
                if (var.x == x && var.y == y)
                    return var.idWorld;
            }
            return 0;
        }
        public void addEntrance(int x, int y, int id)
        {
            Entrances.Add(new Point2d(x, y, id));

        }
    }
}
