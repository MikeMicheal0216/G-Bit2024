using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [System.Serializable]
    public class Save_Data
    {
        //玩家复活点
        public Vector3 savePoint=new Vector3(0,0,0);
        //相机重置点
        public Vector3 cam_newPoint=new Vector3(-0.5f,5.5f,-10f);
        //四种能力
        public bool Climb_A = false;        //爬墙
        public bool Dash_A = false;         //冲刺
        public bool Jump2_A = false;        //二段跳
        public bool Dash2_A = false;        //二段冲刺

        public List<int> collectedLightPoints;      //光点收集列表
        //音频数据（待完成）
    }
    Save_Data save_D=new Save_Data();
    private void Awake()
    {
        instance = this;
    }
    //找json（没有就new一个）
    public Save_Data GetData()
    {
        Save_Data new_saveData= SaveDataSystem.ReadFromJson<Save_Data>("data_json")??new Save_Data();
        return new_saveData;
    }

    //更新玩家复活点和相机重置点
    public void UpdateSavePoint(Vector3 newSavePoint)
    {
        Save_Data data = GetData(); // 加载当前数据
        data.savePoint = newSavePoint;
        SaveDataSystem.SaveByJson("data_json", data); ; // 保存更新后的数据
    }

    public void UpdateCamNewPoint(Vector3 newCamNewPoint)
    {
        Save_Data data = GetData(); // 加载当前数据
        data.cam_newPoint = newCamNewPoint;
        SaveDataSystem.SaveByJson("data_json", data); ; // 保存更新后的数据
    }

    //更新能力获取情况
    public void UpdateAbility(string abilityName, bool isEnabled)
    {
        Save_Data data = GetData(); // 加载当前数据
        switch (abilityName)
        {
            case "Climb_A":
                data.Climb_A = isEnabled;
                break;
            case "Dash_A":
                data.Dash_A = isEnabled;
                break;
            case "Jump2_A":
                data.Jump2_A = isEnabled;
                break;
            case "Dash2_A":
                data.Dash2_A = isEnabled;
                break;
            default:
                Debug.LogWarning("Unknown ability: " + abilityName);
                break;
        }
        SaveDataSystem.SaveByJson("data_json", data); // 保存更新后的数据
    }
    public void UpdateLightList(int lightId)
    {
        Save_Data data = GetData();
        data.collectedLightPoints.Add(lightId);
        SaveDataSystem.SaveByJson("data_json", data);
    }
    public void SaveAudio(Save_Data save_Data)
    {
        
        SaveDataSystem.SaveByJson("data_json", save_Data);
    }
}
