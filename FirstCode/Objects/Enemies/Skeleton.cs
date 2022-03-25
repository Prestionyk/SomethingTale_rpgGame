
namespace FinalGame
{
    class Skeleton : Enemy
    {

        public Skeleton()
        {
            sprite = "  ___   " +
                      " ,o_ )  " +
                      " \"' |_  " +
                     @" _.-/)\ " +
                      "\"  ,-_/ " +
                      " '\"   ; " +
                      "     /  " +
                     @"   /  \ " +
                      " .-'  ,/";
            spriteWidth = 8;
            name = "Skeleton";
            Stats["HP"] = (int)(70 * Difficulty.Modifier());
            Stats["MAXHP"] = Stats["HP"];
            Stats["STR"] = 10;
            Stats["DEF"] = 6;
            Stats["INT"] = 3;
            dropList.Add(new ThrowingKnife());
            dropChance = 5;
            Experience = 4;
        }
    }
}
