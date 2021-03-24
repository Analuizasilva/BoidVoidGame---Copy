using Assets.Scripts.Volume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        //var audioManager = FindObjectOfType<AudioManager>();
        //foreach (Sound sound in audioManager.sounds)
        //{
        //    if (sound.Name == "Theme")
        //    {
        //        if (sound.source.isPlaying) return;
        //        else { audioManager.Play("Theme"); }
        //    }
        //}
        //FindObjectOfType<AudioManager>().Play("Theme");
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}