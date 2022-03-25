
namespace FinalGame
{
    static class CkeckNear
    {
        public static string Check(World world, char check)
        {
            try
            {
                if (world.world[world.GetX(), world.GetY() - 1] == check)
                    return "left";

            }
            catch (System.IndexOutOfRangeException) { };

            try
            {
                if (world.world[world.GetX() - 1, world.GetY()] == check)
                    return "down";

            }
            catch (System.IndexOutOfRangeException) { };
            try
            {
                if (world.world[world.GetX() + 1, world.GetY()] == check)
                    return "up";

            }
            catch (System.IndexOutOfRangeException) { };
            try
            {
                if (world.world[world.GetX(), world.GetY() + 1] == check)
                    return "right";

            }
            catch (System.IndexOutOfRangeException) { };

            return "";
        }

    }
}
