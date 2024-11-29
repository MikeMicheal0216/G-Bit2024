using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 存储系统
/// </summary>
public class SaveDataSystem : MonoBehaviour
{
    //保存json
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }
    //读取json
    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    #region Json
    //保存json内部数据
    public static void SaveByJson(string fileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, fileName);
        try
        {
            File.WriteAllText(path, json);
            Debug.Log(json);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
    //从json读数据
    public static T ReadFromJson<T>(string fileName)
    {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(path)) return default;
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<T>(json);
        return data;
    }
    //删除json
    public static void DeleteSaveFile(string fileName)
    {
        var path = Path.Combine(Application.persistentDataPath, fileName);
        File.Delete(path);
    }
    #endregion
}
