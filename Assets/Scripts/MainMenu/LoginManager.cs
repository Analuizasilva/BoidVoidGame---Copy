using Assets.Scripts.GameModel;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Assets.Scripts.MainMenu.CacheScripts;

namespace Assets.Scripts.MainMenu
{
    [System.Serializable]
    public class LoginManager : MonoBehaviour
    {
        [SerializeField]
        private LoginVM LoginVM;
        private Player[] ListOfPlayers;

        [SerializeField]
        public TMP_InputField PlayerNameInput;
        [SerializeField]
        public GameObject LoginDataEntry;



        void Start()
        {
            StartCoroutine(
            Requester.Get("http://localhost:62448/api/login", (error, data) =>
            { LoadData(error, data); })
            );
        }


        void Update()
        {

        }


        public void LoadData(string error, byte[] data)
        {

            if (!string.IsNullOrEmpty(error))
            {
                Debug.LogError(error);
            }
            
            else
            {
                var requestResult = System.Text.Encoding.Default.GetString(data);
                LoginVM = JsonUtility.FromJson<LoginVM>(requestResult);


                var arrayLenght = LoginVM.PlayersLoginData.Length;
                ListOfPlayers = new Player[arrayLenght];

                if (LoginVM.PlayersLoginData != null)
                {
                    for (int i = 0; i < arrayLenght; i++)
                    {
                        Player player = new Player();
                        player.Id = LoginVM.PlayersLoginData[i].Id;
                        player.Name = LoginVM.PlayersLoginData[i].Name;
                        ListOfPlayers[i] = player;
   
                    }
                }
            }
        }


        public void OkButtonPress()
        {

            var arrayLenght = ListOfPlayers.Length;

            for (int i = 0; i < arrayLenght; i++)
            {
                if (string.IsNullOrEmpty(PlayerNameInput.text))
                {
                    PlayerNameInput.text = string.Empty;
                    break;
                }
                else if (PlayerNameInput.text == ListOfPlayers[i].Name)
                {
                    Context.Set("playerName", PlayerNameInput.text, true);
                    break;
                }
            }
            

            LoginDataEntry.gameObject.SetActive(false);
            Debug.Log("Your Name is " + Context.Get<string>("playerName"));
        }


        public void ClearLogin()
        {
            Context.Delete("playerName", true);
        }

    }
}
