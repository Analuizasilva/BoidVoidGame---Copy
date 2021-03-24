//using Assets.Scripts.AutoMode.PeriodAM;
//using Assets.Scripts.AutoMode.PlayerAM;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

//namespace Assets.Scripts.CacheScripts
//{
//    [RequireComponent(typeof(Button))]

//    public class SaveAutoModeValue : MonoBehaviour
//    {
//        const string PrefPlayerName = "playersvalues";
//        const string PrefPeriodName = "periodsvalues";

//        private PlayerAutoMode Player;
//        private PeriodAutoMode Period;
//        private Button PlayerButton;
//        private Button PeriodButton;


//        void Awake()
//        {
//            PlayerButton = GetComponent<Button>();
//            Player = PlayerButton.GetComponentInParent<PlayerAutoMode>();

//            bool playerSelected = true;

//            PlayerButton.onClick.AddListener(new UnityAction<int>(index =>
//            {
//                PlayerPrefs.SetInt(PrefPlayerName, value: 1);
//                PlayerPrefs.Save();
//            }));

//        }

//        void Start()
//        {
//            if (PlayerPrefs.GetInt("playersvalues") == 1)
//            {
//                Player.AutoModeState = true;
//            }
//            else
//            {
//                Player.AutoModeState = false;
//            }

//        }


//    }
//}
