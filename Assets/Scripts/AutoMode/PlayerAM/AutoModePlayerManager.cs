using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using Assets.Scripts.GameModel;

namespace Assets.Scripts.AutoMode.PlayerAM
{ 
    
    public class AutoModePlayerManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject PlayerAutoModePrefab;
        private AutoModeVM autoMode;


        void Start()
        {
            StartCoroutine(
            Requester.Get("http://localhost:62448/api/playerautomode", (error, data) =>
            { LoadData(error, data); })
            );
        }

   
        void Update()
        {
        
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
                autoMode = JsonUtility.FromJson<AutoModeVM>(requestResult);

                if (autoMode.Players != null)
                {
                    var arrayLenght = autoMode.Players.Length;

                    for (int i = 0; i < arrayLenght; i++)
                    {
                        var playerContent = GameObject.FindGameObjectWithTag("AutoModePlayerContent");
                        PlayerAutoMode player = new PlayerAutoMode();
                        player.Name = autoMode.Players[i].Name;
                        player.AutoModeState = autoMode.Players[i].AutoModeState;
                        var prefab = Instantiate(PlayerAutoModePrefab, playerContent.transform);
                        TextMeshProUGUI playerNameText = prefab.GetComponent<TextMeshProUGUI>();
                        playerNameText.text = player.Name;
                    }
                }
            }
        }

    }
}
