using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 界面基类
/// </summary>
public class UIBase : MonoBehaviour
{
    //注册事件
    public UIEventManager Register(string uiName)
    {
        Transform ui = transform.Find(uiName);
        return UIEventManager.Get(ui.gameObject);
    }
    //显示
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    //隐藏
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    //销毁当前挂载UI
    public virtual void Destroy()
    {
        UIManager.Instance.DestroyOneUI(gameObject.name);
    }
}
