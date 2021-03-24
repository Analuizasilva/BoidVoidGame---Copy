using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPanelManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Prefab;
    private Team team;


    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/team", (error, data) =>
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
            team = new Team() { Players = JsonHelper.GetJsonArray<Player>(requestResult, "Players") };
            //team = JsonUtility.FromJson<Team>(requestResult);
            if (team.Players != null)
            {
                var arrayLenght = team.Players.Length;

                for (var i = 0; i < arrayLenght; i++)
                {
                    var scrollGameObject = GameObject.FindGameObjectWithTag("UserMenuTeamContent").transform;
                    GameObject gameObjectPrefab = Instantiate(Prefab,scrollGameObject);

                    var prefabComponents = gameObjectPrefab.GetComponentsInChildren<Text>();
                    foreach (var component in prefabComponents)
                    {
                        if (component.name == "Name") component.text = team.Players[i].Name;
                        if (component.name == "Attack") component.text = team.Players[i].Attack.ToString();
                        if (component.name == "Defense") component.text = team.Players[i].Defense.ToString();
                        if (component.name == "BoidBattery") component.text = team.Players[i].BoidBattery.ToString();
                        if (component.name == "Respawns") component.text = team.Players[i].Respawns.ToString();
                        if (component.name == "ActionPoints") component.text = team.Players[i].ActionPoints.ToString();
                    }
                    
                }
            }
        }
    }
}
