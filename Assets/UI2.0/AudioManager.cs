using UnityEngine;
using UnityEngine.Audio;

namespace Menuu {
    public class AudioManager : SingletonManager<AudioManager> {

        public AudioMixer mixer;

        public AudioClip hoverSound;
        public AudioClip sliderSound;
        public AudioClip clickSound;

        public void PlayClickSound() {
            GetComponent<AudioSource>().clip = clickSound;
            GetComponent<AudioSource>().Play();
        }
        public void PlayHoverSound() {
            GetComponent<AudioSource>().clip = hoverSound;
            GetComponent<AudioSource>().Play();
        }
        public void PlaySliderSound() {
            GetComponent<AudioSource>().clip = sliderSound;
            GetComponent<AudioSource>().Play();
        }

        public void SetMusicVolume(float value) {
            mixer.SetFloat("MusicVolume", ConvertToDecibel(value));
        }
        public void SetSoundEffectsVolume(float value) {
            mixer.SetFloat("SoundEffectsVolume", ConvertToDecibel(value));
        }
        public void SetMasterVolume(float value) {
            mixer.SetFloat("MasterVolume", ConvertToDecibel(value));
        }
        public void SetAmbientVolume(float value) {
            mixer.SetFloat("AmbientVolume", ConvertToDecibel(value));
        }
        public void SetUIVolume(float value) {
            mixer.SetFloat("UIVolume", ConvertToDecibel(value));
        }

        /**
         * Convert the value coming from our sliders to a decibel value we can
         * feed into the audio mixer.
         */
        public float ConvertToDecibel(float value) {
            // Log(0) is undefined so we just set it by default to -80 decibels
            // which is 0 volume in the audio mixer.
            float decibel = -80f;

            // I think the correct formula is Mathf.Log10(value / 100f) * 20f.
            // Using that yields -6dB at 50% on the slider which is I think is half
            // volume, but I don't feel like it sounds like half volume. :p And I also
            // felt this homemade formula sounds more natural/linear when you go towards 0.
            // Note: We use 0-100 for our volume sliders in the menu, hence the
            // divide by 100 in the equation. If you use 0-1 instead you would remove that.
            if (value > 0) {
                decibel = Mathf.Log(value / 100f) * 17f;
            }

            return decibel;
        }
    }
}
