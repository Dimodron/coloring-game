#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ImagesDirectory : MonoBehaviour
{
    public static int LastFolder(string path)
    {
        string[] files = Directory.GetFiles(path);
        string lastfilePath =  files.Length > 0 ? files[files.Length - 1] : "";
        string name;

        if (lastfilePath == "")
        {
            return 0;
        }
        else 
        {
            name = FolderName(lastfilePath);
            if (int.TryParse(name, out int value))
            {
                return value;
            }
            else {
                Debug.LogError("Last directory have incorrect name, delete this folder");
                AssetDatabase.DeleteAsset($"{path.Substring(path.LastIndexOf("Assets"))}/{name}");
                return 0;
            }
        }
    } 
       
 
    public static string FolderName(string path) {
        path = path.Substring(path.LastIndexOf("\\") + 1);
        return path.Substring(0, path.LastIndexOf("."));
    }
    
    public static bool CreateForlder(string PathToProcessedImage)
    {
        int lastDirNum = LastFolder(PathToProcessedImage);
        int DirNum = lastDirNum+1;
        string DirName;
        switch (DirNum){
                case <= 0:
                    DirName = "001";
                break;
                case < 10:
                    DirName = $"00{DirNum}";
                    break;
                case < 100:
                    DirName = $"0{DirNum}";
                    break;
                case < 1000:
                    DirName = $"{DirNum}";
                    break;
                default:
                    return false;
            }
            Directory.CreateDirectory($"{PathToProcessedImage}/{DirName}");
            Directory.CreateDirectory($"{PathToProcessedImage}/{DirName}/Mesh");
            Directory.CreateDirectory($"{PathToProcessedImage}/{DirName}/Prefab Asset");
            SvgImporter.DirectoryName = DirName;
            AssetDatabase.Refresh();
            return true;
    }
}
#endif