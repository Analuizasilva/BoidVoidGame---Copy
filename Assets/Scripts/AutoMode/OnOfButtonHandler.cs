using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOfButtonHandler : MonoBehaviour
{

    public GameObject OnButton;
    public GameObject OffButton;
    public GameObject AutoModeOff;

    public void OnValueChange()
    {
        bool onOffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (onOffSwitch)
        {
            OnButton.SetActive(true);
            OffButton.SetActive(false);
            AutoModeOff.SetActive(false);
        }
        if (!onOffSwitch)
        {
            OnButton.SetActive(false);
            OffButton.SetActive(true);
            AutoModeOff.SetActive(true);
        }
    }
}
