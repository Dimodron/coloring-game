using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PanZoom : MonoBehaviour

{
    Vector3 touchStart;
     float zoomOutMin = 1;
     float zoomOutMax = 5;
     public Vector2 size;
    public static bool OnThePicture; 
    // Update is called once per frame

    void Update()
    {
        if (OnThePicture) {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            }
            else if (Input.GetMouseButton(0))
            {
                size = new Vector2(Camera.main.transform.GetComponent<Camera>().orthographicSize + 1, Camera.main.transform.GetComponent<Camera>().orthographicSize);
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position = new Vector3(Mathf.Clamp((Camera.main.transform.position.x + direction.x), -2.5f / size.x, 2.5f / size.x), Mathf.Clamp((Camera.main.transform.position.y + direction.y), -3 / size.y, 3 / size.y), 0);
            }
            zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
 
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
