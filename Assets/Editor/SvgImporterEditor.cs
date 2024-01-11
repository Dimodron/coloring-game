using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SvgImporter))]
public class SvgImporterEditor : Editor
{

     public override void OnInspectorGUI()
    {
            GUILayout.Label("Import svg to asset");
        SvgImporter Importer = (SvgImporter)target;
            if (GUILayout.Button("Import"))
            {
            SvgImporter.import();
            }

    }
}
/*
 
PathToProcessedImage = PathToProcessedImage.Substring(PathToProcessedImage.LastIndexOf("Assets"));
        AssetsFilePath = $"{PathToProcessedImage}/{DirectoryName}/Prefab Asset";
        MeshFolderPath = $"{PathToProcessedImage}/{DirectoryName}/Mesh";
 
 
 */