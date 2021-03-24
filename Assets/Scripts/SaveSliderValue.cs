using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SaveSliderValue : MonoBehaviour
{
    const string PrefName = "optionvalue";

    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(new UnityAction<float>(index =>
        {
            PlayerPrefs.SetFloat(PrefName, slider.value);
            PlayerPrefs.Save();
        }));
    }
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(PrefName, 0);
    }
}
