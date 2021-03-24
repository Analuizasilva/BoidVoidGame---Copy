using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFillHandler : MonoBehaviour
{
    [Range(0, 100)]
    public float FillValue = 0;
    public Image CircleFillImage;
    public RectTransform HandlerEdgeImage;
    public RectTransform FillHandler;

    void Start()
    {
        
    }


    void Update()
    {
        FillCircleValue(FillValue);
    }


    void FillCircleValue(float value)
    {
        float fillAmount = (value / 100.0f);
        CircleFillImage.fillAmount = fillAmount;
        float angle = fillAmount * 360;
        FillHandler.localEulerAngles = new Vector3(0, 0, -angle);
        HandlerEdgeImage.localEulerAngles = new Vector3(0, 0, angle);
    }
}
