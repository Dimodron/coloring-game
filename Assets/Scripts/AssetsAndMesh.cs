#if UNITY_EDITOR

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Sprites;

public class AssetsAndMesh : MonoBehaviour
{ 
    private static string SvgFolderPath, SvgFilePath, MeshFolderPath, AssetsFilePath, PathToAssets;
    private static int SerialNumb;
    private static int LastImageFolder;
    static string[]  asset;

    static public void Create(string SvgFilePath, string PathToProcessedImage, string DirectoryName,string BackUpSvg) {
        /*
        PathToProcessedImage = PathToProcessedImage.Substring(PathToProcessedImage.LastIndexOf("Assets"));
        AssetsFilePath = $"{PathToProcessedImage}/{DirectoryName}/Prefab Asset";
        MeshFolderPath = $"{PathToProcessedImage}/{DirectoryName}/Mesh";
        var tessOptions = new VectorUtils.TessellationOptions()
        {
           StepDistance = 100.0f,
           MaxCordDeviation = 0.5f,
           MaxTanAngleDeviation = 0.1f,
           SamplingStepSize = 0.01f
        };
        var sceneInfo = SVGParser.ImportSVG(File.OpenText(SvgFilePath));
        int NrOfLayers = sceneInfo.Scene.Root.Children.Count;
        int CountNumInLine = NrOfLayers.ToString().Length;
        string ZeroBeforeNumb = "";
        SVGParser.SceneInfo[] m_SIArray = new SVGParser.SceneInfo[NrOfLayers];
        List<VectorUtils.Geometry>[] m_Geoms = new List<VectorUtils.Geometry>[NrOfLayers];
        for (int i = 0; i < NrOfLayers; i++)
        {
            m_SIArray[i] = SVGParser.ImportSVG(File.OpenText(SvgFilePath));
            int removed = 0;
            for (int c = 0; c < NrOfLayers; c++)
            {
                if (c != i)
                {
                    m_SIArray[i].Scene.Root.Children.Remove(m_SIArray[i].Scene.Root.Children[c - removed]);
                    removed++;
                }
            }
            if (i.ToString().Length < CountNumInLine)
            {
                while (ZeroBeforeNumb.Length < CountNumInLine - 1)
                {
                    ZeroBeforeNumb += "0";
                }
            }
            m_Geoms[i] = VectorUtils.TessellateScene(m_SIArray[i].Scene, tessOptions);
            Mesh mesh = new Mesh();
            VectorUtils.FillMesh(mesh, m_Geoms[i], 1f, false);
            AssetDatabase.CreateAsset(mesh, $"{MeshFolderPath}/{ZeroBeforeNumb}{i}.asset");
            float LayerZIndex = ((NrOfLayers) - i) * 0.0001f;
            GameObject go = new GameObject($"{i}");
            MeshFilter meshF = go.AddComponent<MeshFilter>();
            meshF.mesh = mesh;
            go.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Colors/00_color");
            go.AddComponent<MeshCollider>();
            var newprefab = PrefabUtility.SaveAsPrefabAsset(go, $"{AssetsFilePath}/{ZeroBeforeNumb}{i}.prefab");
            AssetDatabase.SaveAssets();
            DestroyImmediate(go);
            ZeroBeforeNumb = "";
        }*/
         File.Move(SvgFilePath,$"{BackUpSvg}/{SvgFilePath.Substring(SvgFilePath.LastIndexOf("\\") + 1)}");
    }
    static void Delete() { 
    }
    static void ScenExport() { 
    
    }



    /*
    void Start()
    {


        if (Import)
        {
            PathToAssets = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/") + 1);
            SvgFolderPath = $"Assets/Resources/Svg";
            SvgFilePath = $"{SvgFolderPath}/{NameSvg}.svg";
            MeshFolderPath = $"Assets/Resources/Mesh/{NameSvg}";
            PrefabFolderPath = $"Assets/Resources/PaintPref/{NameSvg}";
            PaintArea = gameObject;

            if (File.Exists(SvgFilePath))
            {
                CreateAssets();
            }
                else 
            {
                Debug.LogError($"Not find file path: {SvgFilePath}");
            }
        }
    }
    
}
*/



    private static bool CreateAssets(string SvgFilePath) {

      




        return true;
        /*var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        var sceneInfo = SVGParser.ImportSVG(File.OpenText(SvgFilePath));
        int NrOfLayers = sceneInfo.Scene.Root.Children.Count;
        int CountNumInLine = NrOfLayers.ToString().Length;
        string ZeroBeforeNumb = "";
        SVGParser.SceneInfo[] m_SIArray = new SVGParser.SceneInfo[NrOfLayers];
        List<VectorUtils.Geometry>[] m_Geoms = new List<VectorUtils.Geometry>[NrOfLayers];
        for (int i = 0; i < NrOfLayers; i++)
        {
            m_SIArray[i] = SVGParser.ImportSVG(File.OpenText(SvgFilePath));
            int removed = 0;
            for (int c = 0; c < NrOfLayers; c++)
            {
                if (c != i)
                {
                    m_SIArray[i].Scene.Root.Children.Remove(m_SIArray[i].Scene.Root.Children[c - removed]);
                    removed++;
                }
            }
            if (i.ToString().Length < CountNumInLine)
            {
                while (ZeroBeforeNumb.Length < CountNumInLine - 1)
                {
                    ZeroBeforeNumb += "0";
                }
            }
            m_Geoms[i] = VectorUtils.TessellateScene(m_SIArray[i].Scene, tessOptions);

            AssetsFilePath = $"{MeshFolderPath}/{ZeroBeforeNumb}{i}_{NameSvg}.asset";

            Mesh mesh = new Mesh();
            VectorUtils.FillMesh(mesh, m_Geoms[i], 1f, false);
            AssetDatabase.CreateAsset(mesh, AssetsFilePath);

            float LayerZIndex = ((NrOfLayers) - i) * 0.0001f;

            GameObject go = new GameObject($"{NameSvg}_{i}");

            MeshFilter meshF = go.AddComponent<MeshFilter>();
            meshF.mesh = mesh;
            go.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Colors/00_color");
            go.AddComponent<MeshCollider>();
            string localPath = $"{PrefabFolderPath}/{ZeroBeforeNumb}{i}_{NameSvg}.prefab";
            var newprefab = PrefabUtility.SaveAsPrefabAsset(go, localPath);
            AssetDatabase.SaveAssets();
            Destroy(go);
            ZeroBeforeNumb = "";*/
        }      
    }

    /*
    protected static bool CreateAssets()
    {
        Debug.Log("Start creating assets");

        if (Directory.Exists(PathToAssets + MeshFolderPath))
        {
            AssetDatabase.DeleteAsset(MeshFolderPath);
        }
        if (Directory.Exists(PathToAssets + PrefabFolderPath))
        {
            AssetDatabase.DeleteAsset(PrefabFolderPath);
        }
        Directory.CreateDirectory(PathToAssets + MeshFolderPath);
        Directory.CreateDirectory(PathToAssets + PrefabFolderPath);


        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };


        var sceneInfo = SVGParser.ImportSVG(File.OpenText(SvgFilePath));

        int NrOfLayers = sceneInfo.Scene.Root.Children.Count;
        int CountNumInLine = NrOfLayers.ToString().Length;
        string ZeroBeforeNumb = "";
        SVGParser.SceneInfo[] m_SIArray = new SVGParser.SceneInfo[NrOfLayers];
        List<VectorUtils.Geometry>[] m_Geoms = new List<VectorUtils.Geometry>[NrOfLayers];

        for (int i = 0; i < NrOfLayers; i++)
        {
            m_SIArray[i] = SVGParser.ImportSVG(File.OpenText(SvgFilePath));
            int removed = 0;
            for (int c = 0; c < NrOfLayers; c++)
            {
                if (c != i)
                {
                    m_SIArray[i].Scene.Root.Children.Remove(m_SIArray[i].Scene.Root.Children[c - removed]);
                    removed++;
                }
            }

            if (i.ToString().Length < CountNumInLine)
            {
                while (ZeroBeforeNumb.Length < CountNumInLine - 1)
                {
                    ZeroBeforeNumb += "0";
                }
            }


            m_Geoms[i] = VectorUtils.TessellateScene(m_SIArray[i].Scene, tessOptions);



            AssetsFilePath = $"{MeshFolderPath}/{ZeroBeforeNumb}{i}_{NameSvg}.asset";

            Mesh mesh = new Mesh();
            VectorUtils.FillMesh(mesh, m_Geoms[i], 1f, false);
            AssetDatabase.CreateAsset(mesh, AssetsFilePath);

            float LayerZIndex = ((NrOfLayers) - i) * 0.0001f;

            GameObject go = new GameObject($"{NameSvg}_{i}");

            MeshFilter meshF = go.AddComponent<MeshFilter>();
            meshF.mesh = mesh;
            go.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Colors/00_color");
            go.AddComponent<MeshCollider>();
            string localPath = $"{PrefabFolderPath}/{ZeroBeforeNumb}{i}_{NameSvg}.prefab";
            var newprefab = PrefabUtility.SaveAsPrefabAsset(go, localPath);
            AssetDatabase.SaveAssets();
            Destroy(go);
            ZeroBeforeNumb = "";
        }
        return false;
    }

}

/*
    void Start()
    {


        if (Import)
        {
            PathToAssets = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/") + 1);
            SvgFolderPath = $"Assets/Resources/Svg";
            SvgFilePath = $"{SvgFolderPath}/{NameSvg}.svg";
            MeshFolderPath = $"Assets/Resources/Mesh/{NameSvg}";
            PrefabFolderPath = $"Assets/Resources/PaintPref/{NameSvg}";
            PaintArea = gameObject;

            if (File.Exists(SvgFilePath))
            {
                CreateAssets();
            }
                else 
            {
                Debug.LogError($"Not find file path: {SvgFilePath}");
            }
        }
    }
    
}
*/
#endif
