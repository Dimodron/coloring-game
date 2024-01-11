using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateColorButon : MonoBehaviour
{
    private Object[] Color;
    
    void Start()
    {
        Color = Resources.LoadAll($"Colors", typeof(Material));
        foreach (var clr in Color)
        {
            GameObject Btn = new GameObject(clr.name);
            Btn.transform.SetParent(gameObject.transform, false);
            Btn.AddComponent<Image>().material = clr as Material;
            Btn.AddComponent<Button>().onClick.AddListener(() => ButtonClicked(clr as Material));
        }
    }
    public void ButtonClicked(Material color)
    {
        ColoringElement.Color = color;
    }
}
