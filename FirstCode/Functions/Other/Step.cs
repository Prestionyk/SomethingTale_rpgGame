
namespace FinalGame.Functions
{
    static class Step
    {
        static readonly char sp = ' ';

        public static void MovingUp(World world)
        {
            try
            {
                if (world.world[world.GetX() - 1, world.GetY()] == sp)
                {
                    world.world[world.GetX(), world.GetY()] = sp;
                    world.setx(-1);
                    world.world[world.GetX(), world.GetY()] = 'X';
                }
            }
            catch (System.IndexOutOfRangeException) { };
        }

        public static void MovingDown(World world)
        {
            try
            {
                if (world.world[world.GetX() + 1, world.GetY()] == sp)
                {
                    world.world[world.GetX(), world.GetY()] = sp;
                    world.setx(1);
                    world.world[world.GetX(), world.GetY()] = 'X';
                }
            }
            catch (System.IndexOutOfRangeException) { };
        }
        public static void MovingLeft(World world)
        {
            try
            {
                if (world.world[world.GetX(), world.GetY() - 1] == sp)
                {
                    world.world[world.GetX(), world.GetY()] = sp;
                    world.sety(-1);
                    world.world[world.GetX(), world.GetY()] = 'X';
                }
            }
            catch (System.IndexOutOfRangeException) { };
        }

        public static void MovingRight(World world)
        {
            try
            {
                if (world.world[world.GetX(), world.GetY() + 1] == sp)
                {
                    world.world[world.GetX(), world.GetY()] = sp;
                    world.sety(1);
                    world.world[world.GetX(), world.GetY()] = 'X';
                }
            }
            catch (System.IndexOutOfRangeException) { };
        }

    }
}
