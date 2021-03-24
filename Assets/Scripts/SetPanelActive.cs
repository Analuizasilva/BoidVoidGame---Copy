using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Threading;

public class SetPanelActive : MonoBehaviour
{
   
    public void ManagePanel()
    {


        if (gameObject.activeInHierarchy)
        {
            Disable();

        }
        else
        {
            SetActive();
        }
    }
    public void SetActive()
    {
        gameObject.SetActive(true);

    }
    public void Disable()
    {
        gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);

    }

}
