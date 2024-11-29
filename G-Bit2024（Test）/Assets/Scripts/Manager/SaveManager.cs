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
        //��Ҹ����
        public Vector3 savePoint=new Vector3(0,0,0);
        //������õ�
        public Vector3 cam_newPoint=new Vector3(-0.5f,5.5f,-10f);
        //��������
        public bool Climb_A = false;        //��ǽ
        public bool Dash_A = false;         //���
        public bool Jump2_A = false;        //������
        public bool Dash2_A = false;        //���γ��

        public List<int> collectedLightPoints;      //����ռ��б�
        //��Ƶ���ݣ�����ɣ�
    }
    Save_Data save_D=new Save_Data();
    private void Awake()
    {
        instance = this;
    }
    //��json��û�о�newһ����
    public Save_Data GetData()
    {
        Save_Data new_saveData= SaveDataSystem.ReadFromJson<Save_Data>("data_json")??new Save_Data();
        return new_saveData;
    }

    //������Ҹ�����������õ�
    public void UpdateSavePoint(Vector3 newSavePoint)
    {
        Save_Data data = GetData(); // ���ص�ǰ����
        data.savePoint = newSavePoint;
        SaveDataSystem.SaveByJson("data_json", data); ; // ������º������
    }

    public void UpdateCamNewPoint(Vector3 newCamNewPoint)
    {
        Save_Data data = GetData(); // ���ص�ǰ����
        data.cam_newPoint = newCamNewPoint;
        SaveDataSystem.SaveByJson("data_json", data); ; // ������º������
    }

    //����������ȡ���
    public void UpdateAbility(string abilityName, bool isEnabled)
    {
        Save_Data data = GetData(); // ���ص�ǰ����
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
        SaveDataSystem.SaveByJson("data_json", data); // ������º������
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
