using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Assets.Scripts.Volume
{
    public class VolumeController : MonoBehaviour
    {

        public AudioManager audioManager;

        // Start is called before the first frame update
        void Start()
        {
            audioManager = AudioManager.instance;
            var sliders = new Slider[] { gameObject.transform.Find("Theme").GetComponent<Slider>(), gameObject.transform.Find("ClickSound").GetComponent<Slider>() };

            foreach (Slider slider in sliders)
            {
                foreach (Sound sound in audioManager.sounds)
                {
                    if (slider.name == sound.Name)
                    {
                        slider.value = sound.source.volume;
                        break;
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetMainVolumeValue(float volume)
        {
            var sounds = audioManager.sounds;
            Sound s = Array.Find(sounds, sound => sound.Name == "Theme");
            s.source.volume = volume;
            SaveSliderValue(volume);
        }

        public void SetGameVolumeValue(float volume)
        {
            var sounds = audioManager.sounds;
            Sound s = Array.Find(sounds, sound => sound.Name == "ClickSound");
            s.source.volume = volume;
            SaveSliderValue(volume);
        }

        public void SetMainVolumeValueToggle(bool toggleTick)
        {
            var sounds = audioManager.sounds;
            Sound s = Array.Find(sounds, sound => sound.Name == "Theme");
            if (toggleTick==false)
            {
                s.source.volume = 0f;
            }
            else
            {
                s.source.volume = s.volume;
            }
            
        }

        public void SetGameVolumeValueToggle(bool toggleTick)
        {
            var sounds = audioManager.sounds;
            Sound s = Array.Find(sounds, sound => sound.Name == "ClickSound");
            if (toggleTick == false)
            {
                s.source.volume = 0f;
            }
            else
            {
                s.source.volume = s.volume;
            }
        }

        void SaveSliderValue(float volume)
        {
            PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
        }
    }
}