using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 开始界面（等存档写了，再修改继续游戏按钮的显隐）
/// </summary>
public class LoginUI : UIBase
{
    public CameraManager cameramain;
    // Start is called before the first frame update
    void Start()
    {
        Register("BtList/StartBt").onclick = OnStartBtClick;
        //Register("BtList/ContinueBt").onclick = OnContinueBtClick;
        //Register("BtList/SettingsBt").onclick = OnSettingsBtClick;
        Register("BtList/ExitBt").onclick = OnExitBtClick;

        cameramain=GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }
    //开始新游戏
    private void OnStartBtClick(GameObject @object, PointerEventData data)
    {
        Hide();

        SceneManager.Instance.InitTilemap<FirstScene>("FirstScene");

        SceneManager.Instance.InitTilemap<BackGround>("BackGround");
        //临时实例化玩家
        GameObject pla=Instantiate(Resources.Load("Player/"+"Player"),null) as GameObject;

        pla.transform.position = new Vector3(0,0,0);

        pla.transform.localScale= new Vector3(3f,3f,3f);

        pla.name = "Player";

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
