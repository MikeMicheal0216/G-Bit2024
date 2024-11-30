using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WinUI : UIBase
{
    private void Start()
    {
        Register("ReturnBt").onclick = OnRetrunBtClick;
    }

    private void OnRetrunBtClick(GameObject @object, PointerEventData data)
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
