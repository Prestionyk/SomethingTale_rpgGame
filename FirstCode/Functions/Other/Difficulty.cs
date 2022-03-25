
using FinalGame.Functions.Menus;

namespace FinalGame
{
    static class Difficulty
    {
        enum difficulty
        {
            Easy,
            Medium,
            Hard
        }

        private static difficulty selectDifficulty = difficulty.Medium;
        public static string Get()
        {
            return selectDifficulty.ToString();
        }

        public static void change()
        {
            if (!MainMenu.getStarted())
            {
                ++selectDifficulty;
                if ((int)selectDifficulty > 2)
                    selectDifficulty = 0;
            }
        }

        public static float Modifier()
        {
            switch (Get())
            {
                case "Easy":
                    return 0.75f;
                case "Medium":
                    return 1f;
                case "Hard":
                    return 1.25f;
            }
            return 1f;
        }

    }
}
