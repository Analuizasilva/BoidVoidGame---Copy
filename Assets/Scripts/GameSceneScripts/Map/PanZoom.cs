using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector2 touchStart;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            Debug.Log(touchStart);
            Debug.Log(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 value = Input.mousePosition;
            Debug.Log(value);
            Debug.Log(Input.mousePosition);
            Vector2 direction = touchStart - value;
            Vector2 cameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            cameraPosition += direction;
        }
    }
}
