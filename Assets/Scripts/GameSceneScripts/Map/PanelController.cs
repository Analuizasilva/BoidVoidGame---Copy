using UnityEngine;
public class PanelController : MonoBehaviour
{
    [SerializeField]
    float zoomOutMin = 1f;
    [SerializeField]
    float zommOutMax = 8f;
    public Camera cam;
    private Vector3 touchStart;
    public float velocity = 5.0f;
    public GameObject TileObjectPrefab;
    public int MapSizeX;
    public int MapSizeY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition();
            cam.transform.position += direction;
        }

        ZoomInAndOutMobile();
        ZoomInAndOut();
        CameraAreaBoundary();
    }

    private void CameraAreaBoundary()
    {
        var tileHeight = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.y - 15;
        var tileWidth = TileObjectPrefab.GetComponent<RectTransform>().sizeDelta.x;

        var rectCamera = cam.GetComponent<RectTransform>();

        var yMax = rectCamera.anchorMin.y;
        var xMax = rectCamera.anchorMin.x;

       var worldVector = transform.TransformPoint(new Vector3(MapSizeX * tileWidth, MapSizeY * tileHeight, 0));

        var yMin = yMax - worldVector.y;
        var xMin = xMax - worldVector.x;

        float xPositionLimit = Mathf.Clamp(cam.transform.position.x, xMin, xMax);
        float yPositionLimit = Mathf.Clamp(cam.transform.position.y, yMin, yMax);

        cam.transform.position = new Vector3(xPositionLimit, yPositionLimit, 0);

     
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

    private Vector3 GetWorldPosition()
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, 0));

        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}


