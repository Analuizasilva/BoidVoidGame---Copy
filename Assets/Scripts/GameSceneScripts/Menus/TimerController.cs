using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimerController : MonoBehaviour
    {
        public static TimerController instance;
        public Text timeCounter;

        private TimeSpan timePlaying;
        private bool timerGoing;

        private float elapsedTime;
        private float initialElapsedTime =10f;
        private void Awake()
        {
            instance = this;
        }


        void Start()
        {
            timeCounter.text = "00:00";
            timerGoing = false;
            BeginTimer();
        }

        private void Update()
        {
            if (timerGoing == false)
            {
                BeginTimer();
            }
        }

        public void BeginTimer()
        {
            timerGoing = true;
            elapsedTime = initialElapsedTime;

            StartCoroutine(UpdateTimer());
        }
        public void EndTimer()
        {
            timerGoing = false;
            
        }

        private IEnumerator UpdateTimer()
        {
            while (timerGoing)
            {
                if (elapsedTime > 0)
                {
                    elapsedTime -= Time.deltaTime;
                    timePlaying = TimeSpan.FromSeconds(elapsedTime);
                    string timePlayingString = timePlaying.ToString("mm':'ss");
                    timeCounter.text = timePlayingString;
                }
                else
                {
                    elapsedTime = initialElapsedTime;
                    Debug.Log("A new turn has started.");
                    elapsedTime -= Time.deltaTime;
                    timePlaying = TimeSpan.FromSeconds(elapsedTime);
                    string timePlayingString = timePlaying.ToString("mm':'ss");
                    timeCounter.text = timePlayingString;
                }
                yield return null;
            }
        }
 
    }
}