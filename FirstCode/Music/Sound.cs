
namespace FinalGame.Music
{
    static class Sound
    {
        private static bool isOn = false;

        public static bool get()
        {
            return isOn;
        }

        public static void change()
        {
            isOn = !isOn;
        }
    }
}
