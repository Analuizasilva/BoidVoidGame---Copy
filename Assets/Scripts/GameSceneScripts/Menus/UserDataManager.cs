using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataManager : MonoBehaviour
{
    public GameObject UserName;
    public GameObject ActionPoints;
    public GameObject Attack;
    public GameObject Defence;

    private UserData userData;

    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/userdata", (error, data) =>
            { LoadData(error, data); })
            );

    }

    private void LoadData(string error, byte[] data)
    {
        if (!string.IsNullOrEmpty(error))
        {
            Debug.LogError(error);
        }
        else
        {
            var requestResult = System.Text.Encoding.Default.GetString(data);

            userData = JsonUtility.FromJson<UserData>(requestResult);



            UserName.GetComponent<Text>().text = userData.Name.ToString();
            ActionPoints.GetComponent<Text>().text = "AP: " + userData.ActionPoints.ToString();
            Attack.GetComponent<Text>().text = "Attack: " + userData.Attack.ToString();
            Defence.GetComponent<Text>().text = "Defence: " + userData.Defense.ToString();


            var playerContent = GameObject.FindGameObjectWithTag("PlayersContent");
            var playerComponent = playerContent.GetComponentInChildren<Player>();

            playerComponent.Name = userData.Name;
            playerComponent.ActionPoints = userData.ActionPoints;

        }
    }
}
