using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SaveManager;
/// <summary>
/// 开始界面
/// </summary>
public class LoginUI : UIBase
{
    protected Save_Data currentData;

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        currentData = SaveDataSystem.ReadFromJson<Save_Data>("data_json")??null;

        button = transform.Find("BtList/ContinueBt").GetComponent<Button>();

        Register("BtList/StartBt").onclick = OnStartBtClick;
        //if (currentData == null)
        //{
        //    button.enabled = false;
        //}
        //else
        //{
        //    button.enabled = true;
        //    Register("BtList/ContinueBt").onclick = OnContinueBtClick;
        //}
        //Register("BtList/SettingsBt").onclick = OnSettingsBtClick;
        Register("BtList/ExitBt").onclick = OnExitBtClick;

        
    }
    //开始新游戏
    private void OnStartBtClick(GameObject @object, PointerEventData data)
    {
        StartCoroutine(LoadNewScene());
        
    }
    ////继续游戏（有存档才会激活并跳转）
    //private void OnContinueBtClick(GameObject @object, PointerEventData data)
    //{
    //    throw new NotImplementedException();
    //}   
    ////设置界面
    //private void OnSettingsBtClick(GameObject @object, PointerEventData data)
    //{
    //    UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    //}
    //退出游戏
    private void OnExitBtClick(GameObject @object, PointerEventData data)
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    IEnumerator LoadNewScene()
    {
        AsyncOperation asyncLoad =SceneManager.LoadSceneAsync(1) ;

        // 等待场景加载完成
        while (asyncLoad.isDone)
        {
            // 可以在这里更新加载进度条
            yield return null;
            Destroy();
        }
    }

}
