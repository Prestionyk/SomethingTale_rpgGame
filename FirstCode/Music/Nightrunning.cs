using System.Media;

namespace FinalGame.Music
{
    static class Nightrunning
    {
        private static SoundPlayer sing = new SoundPlayer(@"Musics\Nightrunning.wav");
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
