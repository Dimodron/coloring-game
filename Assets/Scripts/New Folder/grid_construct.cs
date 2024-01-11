/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grid_construct : MonoBehaviour
{
   
    void Start()
    {
        float width = 720 / 2;
        float height = 1060 / 2;




        GameObject instancePref = Instantiate(go as GameObject, PaintCont);

        instancePref.name = go.name;


        float LayerZIndex = (ElementLenght - i);
        instancePref.transform.localScale = new Vector3(-1, -1, -1);
        instancePref.transform.localRotation = new Quaternion(0, 180, 0, 0);
        instancePref.transform.localPosition = new Vector3(width * -1, height, LayerZIndex);
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

}
*/