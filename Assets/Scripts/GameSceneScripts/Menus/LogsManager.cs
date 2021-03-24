using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Prefab;
    private Log[] logs;


    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/logs", (error, data) =>
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

            var logViewModels = JsonHelper.GetJsonArray<LogViewModel>(requestResult, "Logs");

            logs = new Log[logViewModels.Length];

            for (var logCounter = 0; logCounter < logViewModels.Length; logCounter++)
            {
                logs[logCounter] = logViewModels[logCounter].To();
            }

            var arrayLength = logs.Length;

            for (var i = 0; i < arrayLength; i++)
            {
                var scrollGameObject = GameObject.FindGameObjectWithTag("UserMenuLogsContent").transform;
                GameObject gameObjectPrefab = Instantiate(Prefab, scrollGameObject);
                gameObjectPrefab.GetComponent<Text>().text = "["+logs[i].Timestamp.ToString()+"] - "+logs[i].Event;

            }

        }
    }
}
