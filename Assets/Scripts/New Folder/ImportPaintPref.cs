using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ImportPaintPref : MonoBehaviour
{
    private Object[] ElementImg;
    private float time;
#if UNITY_EDITOR
    [SerializeField]
    private string SvgFilePath;
#endif
    void Start()
    {
        int i = 0;
        string ImgName = PlayerPrefs.GetString("picture");
        Transform PaintCont = new GameObject("PaintContent").transform;
        PaintCont.localScale = new Vector3(0.005f, 0.005f, 1);
        PaintCont.localPosition = new Vector3(0,0,100);
#if UNITY_EDITOR
        if (ImgName == "") {
            ImgName = SvgFilePath;
        }
#endif
        ElementImg = Resources.LoadAll($"PaintPref/{ImgName}", typeof(GameObject));
        int ElementLenght = ElementImg.Length;
        if (ElementLenght == 0){
            SceneManager.LoadScene(0);
        }else {
            foreach (var go in ElementImg)
            {
                float width = 720 / 2;
                float height = 1060 / 2;

               
                
                
                GameObject instancePref = Instantiate(go as GameObject, PaintCont);
                
                instancePref.name = go.name;

               
                float LayerZIndex = (ElementLenght-i);
                instancePref.transform.localScale = new Vector3(-1,-1,-1);
                instancePref.transform.localRotation = new Quaternion(0, 180, 0, 0);
                instancePref.transform.localPosition = new Vector3(width*-1, height, LayerZIndex);
                EventTrigger trigger = instancePref.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerDown;
                entry.callback.AddListener((data) => { EventElementSvgOnDown((PointerEventData)data, instancePref); });
                trigger.triggers.Add(entry);
                EventTrigger.Entry entry2 = new EventTrigger.Entry();
                entry2.eventID = EventTriggerType.PointerUp;
                entry2.callback.AddListener((data) => { EventElementSvgOnUp((PointerEventData)data, instancePref); });
                trigger.triggers.Add(entry2);
                i++;
            }
            
        };

       
    }
    public void EventElementSvgOnDown(PointerEventData data,GameObject instancePref)
    {
        time = Time.time;
        PanZoom.OnThePicture = true;
    }
    public void EventElementSvgOnUp(PointerEventData data, GameObject instancePref)
    {
        time = Time.time - time;
        if (time < 0.2f)
        {
            ColoringElement.ElementImage = instancePref;
            ColoringElement.ColorElement();
        }
        PanZoom.OnThePicture = false;
    }
}
