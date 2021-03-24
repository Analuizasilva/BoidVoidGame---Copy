using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckInternet : MonoBehaviour
{

    [SerializeField]
    public TMP_Text LoadingText;
    [SerializeField]
    public TMP_Text ConnectionErrorText;
    [SerializeField]
    public Button TryAgainButton;
    [SerializeField]
    public Image ConnectionPanel;


    void Start()
    {
        StartCoroutine(CheckInternetConnection());
    }

    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            LoadingText.gameObject.SetActive(false);
            ConnectionErrorText.gameObject.SetActive(true);
            TryAgainButton.gameObject.SetActive(true);
            ConnectionPanel.gameObject.SetActive(true);
        }
        else
        {
            LoadingText.gameObject.SetActive(false);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
