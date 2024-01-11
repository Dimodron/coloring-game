#if UNITY_EDITOR
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SvgImporter : MonoBehaviour
{
    public static GameObject PaintArea;
    public static string DirectoryName;
    public static void import() {
        string PathSvgForImport = $"{Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/") + 1)}Assets/Resources/SVG for import";
        string PathToProcessedImage = $"{Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/") + 1)}Assets/Resources/Asset images for coloring";
        string BackUpSvg = $"{Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/") + 1)}Assets/Resources/Backup SVG";
        string[] ImportSvg = Directory.GetFiles(PathSvgForImport,"*.svg");

        for (int i = 0; i < ImportSvg.Length;i++) {
            if (ImagesDirectory.CreateForlder(PathToProcessedImage)) AssetsAndMesh.Create(ImportSvg[i], PathToProcessedImage, DirectoryName, BackUpSvg);
        }
        
    } 
}
#endif 
