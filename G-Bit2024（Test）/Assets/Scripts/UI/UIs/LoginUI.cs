using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SaveManager;
/// <summary>
/// 开始界面
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
    //开始新游戏
    private void OnStartBtClick(GameObject @object, PointerEventData data)
    {
        Destroy();

        GameUnitManager.Instance.UnitScene<FirstScene>("FirstScene");       //初始化场景

        GameUnitManager.Instance.UnitPlayer();      //初始化玩家

        GameUnitManager.Instance.UnitScenePoint();      //初始化场景转折点

        GameUnitManager.Instance.UnitSavePoint();       //初始化存档点

        GameUnitManager.Instance.UnitPlayer_A();        //初始化技能果实

        GameUnitManager.Instance.UniitLight();      //初始化灵光

        cameramain.enabled=true;

    }
    //继续游戏（有存档才会激活并跳转）
    private void OnContinueBtClick(GameObject @object, PointerEventData data)
    {
        throw new NotImplementedException();
    }   
    //设置界面
    private void OnSettingsBtClick(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    }
    //退出游戏
    private void OnExitBtClick(GameObject @object, PointerEventData data)
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    
}
