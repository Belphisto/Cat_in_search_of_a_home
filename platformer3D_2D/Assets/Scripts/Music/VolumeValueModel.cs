namespace Model
{
    public static class VolumeValueModel 
    {
        // Start is called before the first frame update
        private static float soundVolume = 1f;
        private static float musicVolume = 1f;

        public static void SetSoundVolume(float volume)
        {
            soundVolume = volume;
        }
        public static void SetMusicVolume(float volume)
        {
            musicVolume = volume;
        }

        public static float GetSoundVolume()
        {
            return soundVolume;
        }
        public static float GetMusicVolume()
        {
            return musicVolume;
        }

    }

}
