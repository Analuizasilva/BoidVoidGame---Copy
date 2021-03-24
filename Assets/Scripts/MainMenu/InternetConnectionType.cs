using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;


public class InternetConnectionType : MonoBehaviour
{
    string m_ReachabilityText;
    [SerializeField]
    public TMP_Text WifiOnText;
    //[SerializeField]
    //public TMP_Text WifiOffText;
    [SerializeField]
    public TMP_Text MobileDataOnText;
    //[SerializeField]
    //public TMP_Text MobileDataOffText;


    void Start()
    {
        CheckConnectionType();
    }

    void FixedUpdate()
    {
        CheckConnectionType();

        Debug.Log("Internet : " + m_ReachabilityText);

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            m_ReachabilityText = "Not Reachable.";
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            m_ReachabilityText = "Reachable via carrier data network.";
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            m_ReachabilityText = "Reachable via Local Area Network.";
        }
    }

    public void CheckConnectionType()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            MobileDataOnText.gameObject.SetActive(true);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            WifiOnText.gameObject.SetActive(true);
        }
    }
}