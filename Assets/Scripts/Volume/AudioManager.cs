using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


namespace Assets.Scripts.Volume
{
    public class AudioManager : MonoBehaviour
    {

        public Sound[] sounds;

        public static AudioManager instance;

        void Awake()
        {
            if (instance == null) instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                Debug.Log(s.source.name);
            }
        }
        private void Start()
        {

            Play("Theme");
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<AudioManager>().Play("ClickSound");
            }
        }
        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.Name == name);
            if (s == null) return;
            s.source.Play();
            s.IsPlaying = true;
        }
    }
}