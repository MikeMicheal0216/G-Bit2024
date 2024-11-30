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

        // �ȴ������������
        while (!asyncLoad.isDone)
        {
            // ������������¼��ؽ�����
            yield return null;
            Destroy();
        }
    }
}
