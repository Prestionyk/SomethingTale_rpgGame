
namespace FinalGame.Functions
{
    static class Enter
    {
        public static int World(World world, char check)
        {
            switch (CkeckNear.Check(world, check))
            {
                case "left":
                    return world.getIdWorld(world.GetX(), world.GetY() - 1);
                case "right":
                    return world.getIdWorld(world.GetX(), world.GetY() + 1);
                case "up":
                    return world.getIdWorld(world.GetX() + 1, world.GetY());
                case "down":
                    return world.getIdWorld(world.GetX() - 1, world.GetY());
                default: return -1;
            }
        }

        public static bool Dungeon(World world, char check)
        {
            string result = CkeckNear.Check(world, check);

            if (result != "") return true;
            else return false;

        }

    }
}
