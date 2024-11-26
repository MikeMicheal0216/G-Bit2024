using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ��ʼ���棨�ȴ浵д�ˣ����޸ļ�����Ϸ��ť��������
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
    //��ʼ����Ϸ
    private void OnStartBtClick(GameObject @object, PointerEventData data)
    {
        Hide();

        SceneManager.Instance.InitTilemap<FirstScene>("FirstScene");

        SceneManager.Instance.InitTilemap<BackGround>("BackGround");
        //��ʱʵ�������
        GameObject pla=Instantiate(Resources.Load("Player/"+"Player"),null) as GameObject;

        pla.transform.position = new Vector3(0,0,0);

        pla.transform.localScale= new Vector3(3f,3f,3f);

        pla.name = "Player";

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
