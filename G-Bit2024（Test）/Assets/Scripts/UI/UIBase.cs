using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������
/// </summary>
public class UIBase : MonoBehaviour
{
    //ע���¼�
    public UIEventManager Register(string uiName)
    {
        Transform ui = transform.Find(uiName);
        return UIEventManager.Get(ui.gameObject);
    }
    //��ʾ
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    //����
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    //���ٵ�ǰ����UI
    public virtual void Destroy()
    {
        UIManager.Instance.DestroyOneUI(gameObject.name);
    }
}
