using UnityEngine;
using UnityEngine.UI;

using Model;
namespace Controller
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager instance;
        private AudioSource audio;
        public Slider slider;

        // Start is called before the first frame update
        void Start()
        {
            audio = GetComponent<AudioSource>();
            if (slider != null)
            {
                slider.value = VolumeValueModel.GetMusicVolume();;
            }
        }

        // Update is called once per frame
        void Update()
        {
            audio.volume = VolumeValueModel.GetMusicVolume();
        }

        public void SetVolume(float value)
        {
            VolumeValueModel.SetMusicVolume(value);
        }

    }
}
