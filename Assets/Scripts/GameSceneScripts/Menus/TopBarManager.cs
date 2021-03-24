using Assets.Scripts;
using Assets.Scripts.GameModel;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopBarManager : MonoBehaviour
{
    public GameObject MothershipGameObject;
    public GameObject BoidBatteryGameObject;
    public GameObject ActionPointsGameObject;

    

    [HideInInspector]
    private Mothership Mothership = new Mothership();
    [HideInInspector]
    private BoidBattery BoidBattery =new BoidBattery();


    void AddTextItem(GameObject gameObject, string message)
    {
        gameObject.GetComponent<Text>().text = message;
    }


    void Start()
    {
        string mothershipMessage = Mothership.Health.ToString();
        string baterryMessage = BoidBattery.CurrentValue.ToString();
        AddTextItem(MothershipGameObject, mothershipMessage);
        AddTextItem(BoidBatteryGameObject, baterryMessage);
        AddTextItem(ActionPointsGameObject, "24");

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        var scene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(scene);
    }
    public void GoToSettings()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(sceneIndex);
        var scene = SceneManager.GetSceneByName("MainMenuScene");
        OnSceneLoaded(scene, LoadSceneMode.Single);
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        var sceneObjects = scene.GetRootGameObjects();
        foreach(var item in sceneObjects)
        {
            Debug.Log(item.name);
        }
        var image = GameObject.FindGameObjectWithTag("Image");
        var settings = GameObject.FindGameObjectWithTag("Settings");
        var mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
}
