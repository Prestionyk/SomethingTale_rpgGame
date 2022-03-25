namespace FinalGame
{
    class Guardian : Enemy
    {

        public Guardian()
        {
            sprite = @"    .----.                    " +
                     @"  _/\ ____\      _______      " +
                     @" (/  /    .     /       \     " +
                     @" /  /    /     [  ()  ]  |    " +
                     @"/  /  (\/    .-|_______-.---. " +
                     @"| /    \\_  /  /       / / '\\" +
                     @"\/____/|'.) \ (        \ ' ,'/" +
                     @"       \ \\.' -\   '    '---' " +
                     @"        \ \\  / )'|'   /   |  " +
                     @"         \ \\'  |_ _  |   /   " +
                     @"          \/\\ [_____. ' /    " +
                     @"             \\/   .'  .'\    " +
                     @"              \.-'_.'    |    " +
                     @"              (_.' ,      \   " +
                     @"              |  \\/\     |   ";

            spriteWidth = 30;
            name = "Guardian";
            Stats["HP"] = (int)(200 * Difficulty.Modifier()); ;
            Stats["MAXHP"] = Stats["HP"];
            Stats["STR"] = 15;
            Stats["DEF"] = 10;
            Stats["INT"] = 7;
            dropChance = 3;
            Experience = 8;
        }
    }
}
