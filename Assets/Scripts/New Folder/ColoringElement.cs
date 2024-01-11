using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine.UI;
public class ColoringElement : MonoBehaviour
{
   public static Material Color=Resources.Load<Material>($"Colors/00_color");
   public static GameObject ElementImage;
   public static void ColorElement() {
            Debug.Log("Color :"+ Color.name);
            ElementImage.GetComponent<MeshRenderer>().material = Color;
        }
   }
