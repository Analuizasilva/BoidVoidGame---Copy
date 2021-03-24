using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class PrefabOnClick : MonoBehaviour
{
    public GameObject SidePanel;

    
    public void ManagePanel()
    {
        if (SidePanel.activeInHierarchy)
        {
            Disable(SidePanel);

        }
        else
        {
            SetActive(SidePanel);
        }
    }
    public void SetActive(GameObject gameO)
    {
        gameO.SetActive(true);

    }
    public void Disable(GameObject gameO)
    {
        gameO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);

    }
}
