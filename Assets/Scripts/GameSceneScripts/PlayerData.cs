using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector]
    public UserData userData;
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


            var playerContent = GameObject.FindGameObjectWithTag("PlayersContent");
            var playerComponent = playerContent.GetComponentInChildren<Player>();

            playerComponent.Name = userData.Name;
            playerComponent.ActionPoints = userData.ActionPoints;

        }
    }
}
