using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// ��Ϣ�ܹ�
/// </summary>
public class UIEventManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action<GameObject, PointerEventData> onclick;
    public Action<GameObject, PointerEventData> onenter;
    public Action<GameObject, PointerEventData> onexit;

    public static UIEventManager Get(GameObject obj)
    {
        UIEventManager uIEventManager = obj.GetComponent<UIEventManager>() ?? obj.AddComponent<UIEventManager>();
        return uIEventManager;
    }
    //���
    public void OnPointerClick(PointerEventData eventData)
    {
        onclick?.Invoke(gameObject, eventData);
    }
    //��ͣ
    public void OnPointerEnter(PointerEventData eventData)
    {
        onenter?.Invoke(gameObject, eventData);
    }
    //�����
    public void OnPointerExit(PointerEventData eventData)
    {
        onexit?.Invoke(gameObject, eventData);
    }
}

   
