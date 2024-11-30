using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelUI : UIBase
{
    private void Start()
    {
        Register("ReturnBt").onclick = OnReturnBtClick;
        Register("CloseBt").onclick = OnCloseBtClick;
    }

    private void OnCloseBtClick(GameObject @object, PointerEventData data)
    {
        Hide();
    }

    private void OnReturnBtClick(GameObject @object, PointerEventData data)
    {
        StartCoroutine(ReturnScene());

        GamingManager.Instance.ChangeType(GamingType.None);

        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }
    IEnumerator ReturnScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // 等待场景加载完成
        while (!asyncLoad.isDone)
        {
            // 可以在这里更新加载进度条
            yield return null;
            Destroy();
        }
    }
}
