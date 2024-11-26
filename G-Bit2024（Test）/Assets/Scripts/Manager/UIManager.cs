using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI������
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;

    private List<UIBase> uiBases;  //����UI���涼�̳���UIBase

    private void Awake()
    {
        Instance = this;

        canvasTf = GameObject.Find("Canvas").transform;//��������Ļ���

        uiBases = new List<UIBase>();//��ʼ�����ϣ�������ع���UI���棩
    }
    //��ʾUI
    public UIBase ShowUI<T>(string uiName)where T : UIBase
    {
        UIBase ui = Find(uiName);

        if (ui == null)
        {
            GameObject uiScript=Instantiate(Resources.Load("UI/" + uiName),canvasTf)as GameObject;//ʵ����UI

            uiScript.name = uiName;//��ʵ������UI��������

            ui = uiScript.AddComponent<T>();//��Ӷ�ӦUI�ű�

            uiBases.Add(ui);//ʵ������UI���洢�浽�б��У������´ε���
        }
        else
        {
            ui.Show();
        }
        return ui;
    }
    //��ĳ��UI�ϵĽű�T
    public T GetUI<T>(string uiNmae)where T : UIBase
    {
        UIBase ui=Find(uiNmae);

        return ui == null ? null: ui.GetComponent<T>() ;
    } 
    
    //����UI
    public void HideUI(string uiName)
    {
        UIBase uIBase = Find(uiName);

        if(uIBase != null)
        {
            uIBase.Hide();
        }
    }

    //���ٵ���UI����
    public void DestroyOneUI(string uiNmae)
    {
        UIBase ui = Find(uiNmae);

         if(ui != null)
        {
            uiBases.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //��������UI����
    public void DestroyAllUI(string uiName)
    {
        for(int i = uiBases.Count-1; i >= 0; --i)
        {
            Destroy(uiBases[i]);
        }
        uiBases.Clear();
    }
    //��UI�б��ж�ӦUI�ű�
    public UIBase Find(string uiName)
    {
        for(int i = 0; i < uiBases.Count; ++i)
        {
            if(uiBases[i].name == uiName)
            {
                return uiBases[i];
            }
            
        }return null;
    }
}
