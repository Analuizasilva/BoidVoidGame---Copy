using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameSceneScripts.Menus
{
    public class ScoreboardPanel:MonoBehaviour
    {
        [SerializeField]
        public GameObject Prefab;
        private Scoreboard scoreboard;


        void Start()
        {
            StartCoroutine(
                Requester.Get("http://localhost:62448/api/scoreboard", (error, data) =>
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

                scoreboard = JsonUtility.FromJson<Scoreboard>(requestResult);
                if (scoreboard.Teams != null)
                {
                    var arrayLenght = scoreboard.Teams.Length;

                    for (var i = 0; i < arrayLenght; i++)
                    {
                        var cellsCaptured = 18;
                        var enemiesDefeated = 3;
                        var superstructures = 2;
                        var pointOfInterest = 1;

                        float attack = 0;
                        float defense = 0;

                        foreach(var item in scoreboard.Teams[i].Players)
                        {
                            attack += item.Attack;
                            defense += item.Defense;
                        }

                        var scrollGameObject = GameObject.FindGameObjectWithTag("Content").transform;
                        GameObject gameObjectPrefab = Instantiate(Prefab, scrollGameObject);

                        var prefabComponents = gameObjectPrefab.GetComponentsInChildren<Text>();

                        foreach (var component in prefabComponents)
                        {
                            if (component.name == "Name") component.text = scoreboard.Teams[i].Name;
                            if (component.name == "CellsCaptured") component.text = cellsCaptured.ToString();
                            if (component.name == "EnemiesDefeated") component.text = enemiesDefeated.ToString();
                            if (component.name == "Attack") component.text = attack.ToString();
                            if (component.name == "Defense") component.text = defense.ToString();
                            if (component.name == "Superstructures") component.text = superstructures.ToString();
                            if (component.name == "PointsOfInterest") component.text = pointOfInterest.ToString();
                        }

                    }
                }
            }
        }
    }
}
