using System.Media;

namespace FinalGame.Music
{
    static class CyberIntro
    {
        private static SoundPlayer sing = new SoundPlayer(@"Musics\CyberIntro.wav");
        public static void Play()
        {
            if (Sound.get())
                sing.PlayLooping();
        }
        public static void Stop()
        {
            sing.Stop();
        }

    }
}
