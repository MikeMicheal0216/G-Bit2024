using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI管理器
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;

    private List<UIBase> uiBases;  //所有UI界面都继承自UIBase

    private void Awake()
    {
        Instance = this;

        canvasTf = GameObject.Find("Canvas").transform;//找世界里的画布

        uiBases = new List<UIBase>();//初始化集合（储存加载过的UI界面）
    }
    //显示UI
    public UIBase ShowUI<T>(string uiName)where T : UIBase
    {
        UIBase ui = Find(uiName);

        if (ui == null)
        {
            GameObject uiScript=Instantiate(Resources.Load("UI/" + uiName),canvasTf)as GameObject;//实例化UI

            uiScript.name = uiName;//改实例化的UI界面名字

            ui = uiScript.AddComponent<T>();//添加对应UI脚本

            uiBases.Add(ui);//实例化的UI界面储存到列表中，方便下次调用
        }
        else
        {
            ui.Show();
        }
        return ui;
    }
    //找某个UI上的脚本T
    public T GetUI<T>(string uiNmae)where T : UIBase
    {
        UIBase ui=Find(uiNmae);

        return ui == null ? null: ui.GetComponent<T>() ;
    } 
    
    //隐藏UI
    public void HideUI(string uiName)
    {
        UIBase uIBase = Find(uiName);

        if(uIBase != null)
        {
            uIBase.Hide();
        }
    }

    //销毁单个UI界面
    public void DestroyOneUI(string uiNmae)
    {
        UIBase ui = Find(uiNmae);

         if(ui != null)
        {
            uiBases.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //销毁所有UI界面
    public void DestroyAllUI(string uiName)
    {
        for(int i = uiBases.Count-1; i >= 0; --i)
        {
            Destroy(uiBases[i]);
        }
        uiBases.Clear();
    }
    //找UI列表中对应UI脚本
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
