using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PaintZoom : MonoBehaviour
{
    private Vector3 touchStart, direction, ObjectStartPoz;
    private Vector2 DisplayRation, BordersMovementZoneMax, BordersMovementZoneMin;
    private float zoomOutMin, size, zoomOutMax = 4,zoomSpeed=0.2f, scaleY, scaleX;
    public static  bool StopMoveObject = true;

    private void Start()
    {
        

        zoomOutMin = gameObject.transform.localScale.x;
        size = zoomOutMin;
        DisplayRation = new Vector2(Screen.width / gameObject.transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.x, Screen.height / gameObject.transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.y);
        BordersMovementZoneMax = new Vector2(gameObject.transform.parent.GetComponent<RectTransform>().rect.width * 0.7f, gameObject.transform.parent.GetComponent<RectTransform>().rect.height * 0.7f);
        BordersMovementZoneMin = new Vector2(gameObject.transform.parent.GetComponent<RectTransform>().rect.width * -0.7f, gameObject.transform.parent.GetComponent<RectTransform>().rect.height * -0.7f);
    }
    void Update()
    {
        if (!StopMoveObject) {
            scaleY = gameObject.transform.localScale.y/1.5f;
            scaleX = gameObject.transform.localScale.x/2f;


            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
                ObjectStartPoz = gameObject.transform.localPosition;
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);
                
                Vector2 touchZeroPrevPos = ConvertCordInDrawArea(touchZero.position-touchZero.deltaPosition);
                Vector2 touchOnePrevPos = ConvertCordInDrawArea(touchOne.position - touchOne.deltaPosition);

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;
            
                zoom(difference);
                
            }
            else if (Input.GetMouseButton(0))
            {
                direction = touchStart - Input.mousePosition;
                direction.x = direction.x / DisplayRation.x;
                direction.y = direction.y / DisplayRation.y;
                gameObject.transform.localPosition = new Vector3(Mathf.Clamp(ObjectStartPoz.x - direction.x, BordersMovementZoneMin.x * scaleX, BordersMovementZoneMax.x * scaleX), Mathf.Clamp(ObjectStartPoz.y - direction.y, BordersMovementZoneMin.y * scaleY, BordersMovementZoneMax.y * scaleY), 1);
            }
        }
    }
    private void zoom(float increment)
    {
        if (increment < 0)
        {
            size -= zoomSpeed;
            gameObject.transform.localPosition = new Vector3(Mathf.Clamp(gameObject.transform.localPosition.x, BordersMovementZoneMin.x * scaleX, BordersMovementZoneMax.x * scaleX), Mathf.Clamp(gameObject.transform.localPosition.y, BordersMovementZoneMin.y * scaleY, BordersMovementZoneMax.y * scaleY), 1);
        }
        if (increment > 0) { size += zoomSpeed; }
        float scale = Mathf.Clamp(size, zoomOutMin, zoomOutMax);
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }
    private Vector3 ConvertCordInDrawArea(Vector3 input) {
        return new Vector3(input.x - GameObject.Find("Canvas").GetComponent<CanvasScaler>().referenceResolution.x, input.y - GameObject.Find("ToolkitWindow").GetComponent<RectTransform>().rect.height - (gameObject.transform.parent.GetComponentInParent<RectTransform>().rect.height / 2), 0);
    }
}