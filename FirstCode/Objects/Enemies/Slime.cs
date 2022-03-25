namespace FinalGame
{
    class Slime : Enemy
    {

        public Slime()
        {

            sprite = "    _-----_    " +
                     "  .        '-  " +
                    @" ' ()    ()  ` " +
                    @"'    .___.    ." +
                    @"\.___________.'";

            spriteWidth = 15;
            name = "Slime";
            Stats["HP"] = (int)(20 * Difficulty.Modifier());
            Stats["MAXHP"] = Stats["HP"];
            Stats["STR"] = 9;
            Stats["DEF"] = 100;
            Stats["INT"] = 4;
            dropList.Add(new HealthPotion());
            dropChance = 4;
            Experience = 2;
        }
    }
}
