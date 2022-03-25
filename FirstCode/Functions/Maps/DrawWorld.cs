using System;

namespace FinalGame.Functions
{
    static class DrawWorld
    {
        public static void Draw(World world)
        {
            Console.SetCursorPosition(0, 0);

            string Map = "";

            int range = 17; //Nie większe niż 1/2 Size
            int xmax, ymax, xmin, ymin;

            /////////////////COUNT_AREA/////////////////
            if ((world.GetY() - range) <= 0)
            {
                ymin = 0;
                ymax = (2 * range);
            }
            else if ((world.GetY() + range) >= world.GetSizeY())
            {
                ymax = world.GetSizeY();
                ymin = world.GetSizeY() - ((2 * range));
            }
            else
            {
                ymin = world.GetY() - range;
                ymax = world.GetY() + range;
            }
            //////////////X////////////
            range /= 2;
            if ((world.GetX() - range) <= 0)
            {
                xmin = 0;
                xmax = (2 * range);
            }
            else if ((world.GetX() + range) >= world.GetSizeX())
            {
                xmax = world.GetSizeX();
                xmin = world.GetSizeX() - ((2 * range));
            }
            else
            {
                xmin = world.GetX() - range;
                xmax = world.GetX() + range;
            }
            ////////////////DRAW_AREA_MAP////////////////
            for (int i = xmin; i <= xmax; i++)
            {
                for (int j = ymin; j <= ymax; j++)
                {
                    Map += world.world[i, j].ToString();
                }
                Map += "\n";
            }
            Console.Write(Map);

        }

    }
}
