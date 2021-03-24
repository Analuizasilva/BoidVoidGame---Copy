using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanelManager : MonoBehaviour
{
    public GameObject FightsWonText;
    public GameObject FightsLostText;
    public GameObject FieldsCapturedText;
    public GameObject RespawnsText;

    private PlayerStatistics playerStatistics;



    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/statistics", (error, data) =>
                 {LoadData(error, data);})
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

            playerStatistics = JsonUtility.FromJson<PlayerStatistics>(requestResult);



            FightsWonText.GetComponent<Text>().text = "Fights Won: " + playerStatistics.FightsWon.ToString();
            FightsLostText.GetComponent<Text>().text = "Fights Lost: " + playerStatistics.FightsLost.ToString();
            FieldsCapturedText.GetComponent<Text>().text = "Fields Captured: " + playerStatistics.FieldsCaptured.ToString();
            RespawnsText.GetComponent<Text>().text = "Respawns: " + playerStatistics.Respawns.ToString();

        }
    }

}
