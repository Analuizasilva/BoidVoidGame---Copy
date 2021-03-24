using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameModel;
using UnityEngine.UI;
using BlockBase.BoidGame.BoidVoidGame.Assets.Scripts;

public class BoidBatteryManager : MonoBehaviour
{
    public GameObject MaxCapacityText;
    public GameObject CurrentValueText;
    public GameObject AttackText;
    public GameObject DefenseText;

    
    //Bonus Game Objects
    public GameObject AttackBonusText;
    public GameObject DefenseBonusText;
    public GameObject BoidBatteryBonusText;
    public GameObject ActionPointsBonusText;

    private BoidBattery boidBattery= new BoidBattery();
    public Slider slider;

    void Start()
    {
        StartCoroutine(
            Requester.Get("http://localhost:62448/api/boidbattery", (error, data) =>
            { LoadData(error, data); })
            );

    }
    

    private void LoadData(string error, byte[] data)
    {
        if (!string.IsNullOrEmpty(error))
        {
            Debug.LogError(error);
        }
        else
        {
            var requestResult = System.Text.Encoding.Default.GetString(data);

            boidBattery = JsonUtility.FromJson<BoidBattery>(requestResult);



            MaxCapacityText.GetComponent<Text>().text = "Max Capacity: "+boidBattery.MaxCapacity.ToString();
            CurrentValueText.GetComponent<Text>().text = "Current Value: " + boidBattery.CurrentValue.ToString();
            
        }
    }
    private void Update()
    {
        var attackPercentage = slider.value;
        var defensePercentage = 100 - attackPercentage;

        var attackValue = boidBattery.CurrentValue * (attackPercentage / 100);
        var defenseValue = boidBattery.CurrentValue * (defensePercentage / 100);

        AttackText.GetComponent<Text>().text = attackValue.ToString();
        DefenseText.GetComponent<Text>().text = defenseValue.ToString();
    }
}
