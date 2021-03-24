using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace BlockBase.BoidGame.BoidVoidGame.Assets.Scripts
{
    public class Requester
    {
        private CheckInternet checkInternet;
        public static IEnumerator Get(string address, Action<string, byte[]> callback)
        {
            //checkInternet.Start();
            var www = UnityWebRequest.Get(address);
            yield return www.SendWebRequest();
            callback.Invoke(www.error, www.downloadHandler.data);
        }

        public static IEnumerator Post(string address, Dictionary<string, string> requestData, Action<string, byte[]> callback)
        {
            var www = UnityWebRequest.Post(address, requestData);
            yield return www.SendWebRequest();
            callback.Invoke(www.error, www.downloadHandler.data);
        }
    }
}

