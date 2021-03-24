using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    float zoomOutMin = 1f;
    [SerializeField]
    float zommOutMax = 8f;
    public Camera cam;
    public float groundZ = 0;
    private Vector3 touchStart; 

    private void Update()
    {
        ZoomInAndOutMobile();
        ZoomInAndOut();

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            cam.transform.position += direction;
        }
    }

    void ZoomInAndOut()
    {
        if (Camera.main.orthographicSize > zoomOutMin)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            {
                Camera.main.orthographicSize -= 1;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if (Camera.main.orthographicSize < zommOutMax)
            {
                Camera.main.orthographicSize += 1;
            }
        }

        //var positionValueX = Camera.main.transform.localPosition.x;
        //var positionValueY = Camera.main.transform.localPosition.y;
        //var rect = gameObject.GetComponent<Transform>();

        //if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        //{
        //    if (positionValueX < zommOutMax && positionValueY < zommOutMax)
        //    {
        //        positionValueX += 0.1f;
        //        positionValueY += 0.1f;
        //        rect.localPosition = new Vector3(positionValueX, positionValueY, 0);
        //    }
        //}

        //if (Input.GetAxis("Mouse ScrollWheel") < 0) // backwards
        //{
        //    if (positionValueX > zoomOutMin && positionValueY > zoomOutMin)
        //    {
        //        positionValueX -= 0.1f;
        //        positionValueY -= 0.1f;
        //        rect.localPosition = new Vector3(positionValueX, positionValueY, 0);
        //    }
        //}
    }

    void ZoomInAndOutMobile()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPreviousPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPos = touchOne.position - touchOne.deltaPosition;

            float previousMagnitude = (touchZeroPreviousPos - touchOnePreviousPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - previousMagnitude;

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - (difference * 0.01f), zoomOutMin, zommOutMax);
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }


}


