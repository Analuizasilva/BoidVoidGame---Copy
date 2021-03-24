using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public GameObject AttackPercentage;
    public GameObject DefencePercentage;

    public void SetValues()
    {
        int MaxValue=90;
        int MinValue=10;
        var value = gameObject.GetComponent<Slider>().value;
        if (value > MaxValue)
        {
            gameObject.GetComponent<Slider>().value=MaxValue;
        }
        if (value < MinValue)
        {
            gameObject.GetComponent<Slider>().value = MinValue;
        }
    }


    private void Start()
    {
        var slider = gameObject.GetComponent<Slider>();
        var attackValue = slider.value;
        AttackPercentage.GetComponent<Text>().text = "Attack: " + attackValue.ToString() + "%";
        var defenceValue = 100 - attackValue;
        DefencePercentage.GetComponent<Text>().text = "Defence: " + defenceValue.ToString() + "%";
    }
    private void Update()
    {
        var slider = gameObject.GetComponent<Slider>();
        var attackValue = (int)slider.value;
        AttackPercentage.GetComponent<Text>().text = attackValue.ToString() + "%";
        var defenceValue = 100 - attackValue;
        DefencePercentage.GetComponent<Text>().text = defenceValue.ToString() + "%";
    }
}
