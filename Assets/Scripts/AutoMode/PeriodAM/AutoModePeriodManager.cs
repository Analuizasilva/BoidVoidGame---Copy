using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.AutoMode.PeriodAM
{

    public class AutoModePeriodManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject PeriodAutoModePrefab;
        private AutoModeVM autoMode;



        void Start()
        {
            //GeneratePeriodData();

            StartCoroutine(
            Requester.Get("http://localhost:62448/api/periodautomode", (error, data) =>
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
                if (autoMode.Periods != null)
                {
                    var arrayLenght = autoMode.Periods.Length;

                    for (int i = 0; i < arrayLenght; i++)
                    {
                        var periodContent = GameObject.FindGameObjectWithTag("AutoModePeriodContent");
                        PeriodAutoMode period = new PeriodAutoMode();
                        period.Name = autoMode.Periods[i].Name;
                        period.AutoModeState = autoMode.Periods[i].AutoModeState;
                        var prefab = Instantiate(PeriodAutoModePrefab, periodContent.transform);
                        TextMeshProUGUI periodNameText = prefab.GetComponent<TextMeshProUGUI>();
                        periodNameText.text = period.Name;
                    }
                }
            }
        }
    }

}

