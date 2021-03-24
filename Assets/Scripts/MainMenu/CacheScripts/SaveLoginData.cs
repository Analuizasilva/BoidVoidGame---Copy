//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using Assets.Scripts.GameModel;

//namespace Assets.Scripts.MainMenu.CacheScripts
//{

//    public class SaveLoginData : MonoBehaviour
//    {
//        [SerializeField]
//        public TMP_InputField PlayerNameInput;
//        [SerializeField]
//        public GameObject LoginDataEntry;
//        private Player[] Players;
//        private LoginManager LoginManager;

        
//        public void OkButtonPress(string playerName)
//        {
//            var listOfPlayers = LoginManager.ListOfPlayers;

//            if (string.IsNullOrEmpty (PlayerNameInput.text) )
//            {
//                PlayerNameInput.text = string.Empty;
//            }
//            else if(PlayerNameInput.text == playerName)
//            {
//                Context.Set("playerName", PlayerNameInput.text, true);
//            }
            
//            LoginDataEntry.gameObject.SetActive(false);
//            Debug.Log("Your Name is " + Context.Get<string>("playerName"));
//        } 

//        public void ClearLogin()
//        {
//            Context.Delete("playerName", true);
//        }



//    }

//}
