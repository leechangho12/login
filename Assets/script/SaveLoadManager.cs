using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    //public static VersionData _versionData = new VersionData();

    //public static bool FileCheck(string saveFileName)
    //{
    //    if (!File.Exists(GetFilePath(saveFileName)))
    //        return false;
    //    else
    //        return true;
    //}
    //public static VersionData Load(string saveFileName)
    //{
    //    if (!File.Exists(GetFilePath(saveFileName)))
    //    {
    //        Debug.LogError("File " + GetFilePath(saveFileName) + " not found !");

    //        return null;
    //    }

    //    return JsonHelper.FromJson<VersionData>(File.ReadAllText(GetFilePath(saveFileName)));
    //}

    //public static void Save(string saveFileName)
    //{
    //    string jsonData = JsonHelper.ToJson(GameManager.instance.versionData);
    //    File.WriteAllText(GetFilePath(saveFileName), jsonData);

    //    Debug.Log("Galaxy saved to " + GetFilePath(saveFileName));
    //}

    //public static string GetFilePath(string saveFileName)
    //{
    //    return Path.Combine(Application.persistentDataPath, saveFileName + ".json");
    //}

}
