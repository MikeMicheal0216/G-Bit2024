using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SaveManager;
/// <summary>
/// ��ʼ����
/// </summary>
public class LoginUI : UIBase
{
    public CameraManager cameramain;

    protected Save_Data currentData;

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        currentData = SaveDataSystem.ReadFromJson<Save_Data>("data_json")??null;

        button = transform.Find("BtList/ContinueBt").GetComponent<Button>();

        Register("BtList/StartBt").onclick = OnStartBtClick;
        if (currentData == null)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
            Register("BtList/ContinueBt").onclick = OnContinueBtClick;
        }
        Register("BtList/SettingsBt").onclick = OnSettingsBtClick;
        Register("BtList/ExitBt").onclick = OnExitBtClick;

        cameramain=GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }
    //��ʼ����Ϸ
    private void OnStartBtClick(GameObject @object, PointerEventData data)
    {
        Destroy();

        GameUnitManager.Instance.UnitScene<FirstScene>("FirstScene");       //��ʼ������

        GameUnitManager.Instance.UnitPlayer();      //��ʼ�����

        GameUnitManager.Instance.UnitScenePoint();      //��ʼ������ת�۵�

        GameUnitManager.Instance.UnitSavePoint();       //��ʼ���浵��

        GameUnitManager.Instance.UnitPlayer_A();        //��ʼ�����ܹ�ʵ

        GameUnitManager.Instance.UniitLight();      //��ʼ�����

        cameramain.enabled=true;

    }
    //������Ϸ���д浵�Żἤ���ת��
    private void OnContinueBtClick(GameObject @object, PointerEventData data)
    {
        throw new NotImplementedException();
    }   
    //���ý���
    private void OnSettingsBtClick(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    }
    //�˳���Ϸ
    private void OnExitBtClick(GameObject @object, PointerEventData data)
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    
}
