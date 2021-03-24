using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.MainMenu.CacheScripts
{
    public class LoadLoginData : MonoBehaviour
    {
        [SerializeField]
        public TMP_Text LoggedPlayerName;
        [SerializeField]
        public Button StartButton;
        [SerializeField]
        public Button LoginButton;

        void Start()
        {
            CheckPlayerLogged();
        }

        void FixedUpdate()
        {
            LoggedPlayerName.text = Context.Get<string>("playerName");
            CheckPlayerLogged();
        }

        void CheckPlayerLogged()
        {
            var internetNotReachable = Application.internetReachability == NetworkReachability.NotReachable;
            var name = Context.Get<string>("playerName");
            LoggedPlayerName.text = name;

            if (string.IsNullOrEmpty(LoggedPlayerName.text) && internetNotReachable)
            {
                StartButton.gameObject.SetActive(false);
                LoginButton.gameObject.SetActive(false);
                LoggedPlayerName.gameObject.SetActive(false);
            }
            else if (string.IsNullOrEmpty(LoggedPlayerName.text) && internetNotReachable != true)
            {
                StartButton.gameObject.SetActive(false);
                LoginButton.gameObject.SetActive(true);
                LoggedPlayerName.gameObject.SetActive(false);
            }
            else if (!string.IsNullOrEmpty(LoggedPlayerName.text) && internetNotReachable != true)
            {
                StartButton.gameObject.SetActive(true);
                LoginButton.gameObject.SetActive(false);
                LoggedPlayerName.gameObject.SetActive(true);

            }
        }

    }
}
