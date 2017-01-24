using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundManager
    {
        private static SoundManager sMan = null;
        IrrKlang.ISoundEngine sndEngine = null;
        IrrKlang.ISound music = null;

      //  music = sndEngine.Play2D("fastinvader4.wav");
        //    music.Volume = 0.5f;

        public static SoundManager createInstance()
        {
            if (sMan == null)
            {
                sMan = new SoundManager();
                sMan.sndEngine = new IrrKlang.ISoundEngine();
            }

            return sMan;
        }

        public static SoundManager getInstance()
        {
            return sMan;
        }

        public static void playFile(String file)
        {
            SoundManager sMan = SoundManager.getInstance();
            sMan.music = sMan.sndEngine.Play2D(file);
        }

        public static void changeVolume(float vol)
        {
            SoundManager sMan = SoundManager.getInstance();
            sMan.music.Volume = vol;
        }

        public static void update()
        {
            SoundManager sMan = SoundManager.getInstance();
            sMan.sndEngine.Update();
        }

    }
}
